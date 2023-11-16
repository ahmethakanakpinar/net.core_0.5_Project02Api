using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.UserDto;
using HotelProject.Web.Dtos.UserRoleDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class UserRoleController : Controller
    {
        private readonly IAppRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;

        public UserRoleController(IAppRoleService roleService, IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _roleService = roleService;
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
    }
}
