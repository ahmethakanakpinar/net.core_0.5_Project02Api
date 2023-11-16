using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.UserDto;
using HotelProject.Web.Dtos.UserRoleDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class UserRoleController : Controller
    {
        private readonly IAppRoleService _roleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;

        public UserRoleController(IAppRoleService roleService, UserManager<AppUser> userManager, IAppUserService userService, IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _roleService = roleService;
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roledata = _roleService.TGetList();
            var values = _mapper.Map<List<ResultUserRoleDto>>(roledata);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddUserRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole(CreateUserRoleDto createUserRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appRole = new AppRole()
            {
                Name = createUserRoleDto.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "UserRole");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var roleToDelete = _roleService.TGetById(id);
            if (!(roleToDelete.Id == 1 || roleToDelete.Id == 2))
            {
                var usersInRole = _userService.TGetAppUserSameAppRole(id);
                var UserRoleList = _mapper.Map<List<UpdateUserSameUserRoleDto>>(usersInRole);

                foreach (var user in UserRoleList)
                {
                    var getuser = _userService.TGetById(user.Id);
                    getuser.AppRoleId = 2;

                    var updateResult = await _userManager.UpdateAsync(getuser);
               
                }
     

                var result = await _roleManager.DeleteAsync(roleToDelete);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "UserRole");
                }

            }
            return RedirectToAction("Index", "UserRole");
        }
    }
}
