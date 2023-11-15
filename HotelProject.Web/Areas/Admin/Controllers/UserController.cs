using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.AboutDto;
using HotelProject.Web.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IAppUserService appUserService, IMapper mapper)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var user = _appUserService.TGetAppRole();
            var values = _mapper.Map<List<ResultUserDto>>(user);
            return View(values);
        }
        public IActionResult AddUser()
        {
            return View();
        }
    }
}
