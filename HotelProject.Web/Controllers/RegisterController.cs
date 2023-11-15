using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDto registerUserDto)
        {
            registerUserDto.AppRoleId = 2;
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                UserName = registerUserDto.UserName,
                Name = registerUserDto.Name,
                Surname = registerUserDto.Surname,
                Email = registerUserDto.Email,
                AppRoleId = registerUserDto.AppRoleId
            };
            var result = await _userManager.CreateAsync(appUser, registerUserDto.PasswordHash);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
