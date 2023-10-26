using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
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
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                UserName = createRegisterDto.UserName,
                Name = createRegisterDto.Name,
                Surname = createRegisterDto.Surname,
                Email = createRegisterDto.Email,
            };
            var result = await _userManager.CreateAsync(appUser, createRegisterDto.PasswordHash);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
