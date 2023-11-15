﻿using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.AboutDto;
using HotelProject.Web.Dtos.RegisterDto;
using HotelProject.Web.Dtos.StaffDto;
using HotelProject.Web.Dtos.UserDto;
using HotelProject.Web.Dtos.UserRoleDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppRoleService _appRoleService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IAppRoleService appRoleService, IAppUserService appUserService, IMapper mapper)
        {
            _userManager = userManager;
            _appRoleService = appRoleService;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var user = _appUserService.TGetAppRole();
            var values = _mapper.Map<List<ResultUserDto>>(user);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            var role = _appRoleService.TGetList();
            var data = _mapper.Map<List<ResultUserRoleDto>>(role);
            // SelectListItem listesine dönüştürme
            List<SelectListItem> values = data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.AppUserRoles = values;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserDto createUserDto)
        {
               
            if (!ModelState.IsValid)
            {
                    return View();
            }
            if (createUserDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(createUserDto.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await createUserDto.Image.CopyToAsync(stream);
                createUserDto.ImageUrl = "/userimage/" + imagename;
            }
            var appUser = new AppUser()
            {
                UserName = createUserDto.UserName,
                Name = createUserDto.Name,
                Surname = createUserDto.Surname,
                City = createUserDto.City,
                ImageUrl = createUserDto.ImageUrl,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                AppRoleId = createUserDto.AppRoleId
                
            };
            
            var result = await _userManager.CreateAsync(appUser, createUserDto.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();

        }
    }
}
