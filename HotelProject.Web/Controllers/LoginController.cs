using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.PasswordHash, true, true);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
