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
using System.Data;
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
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {

            var userupdate = _appUserService.TGetById(id);
            var value = _mapper.Map<UpdateUserDto>(userupdate);

            var role = _appRoleService.TGetList();
            var data = _mapper.Map<List<ResultUserRoleDto>>(role);
            // SelectListItem listesine dönüştürme
            List<SelectListItem> userroles = data.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.AppUserRoles = userroles;

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = _appUserService.TGetById(updateUserDto.Id);

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (updateUserDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(updateUserDto.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await updateUserDto.Image.CopyToAsync(stream);
                updateUserDto.ImageUrl = "/userimage/" + imagename;
                user.ImageUrl = updateUserDto.ImageUrl;
            }

            user.UserName = updateUserDto.UserName;
            user.Name = updateUserDto.Name;
            user.Surname = updateUserDto.Surname;
            user.City = updateUserDto.City;
            user.Email = updateUserDto.Email;
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.AppRoleId = updateUserDto.AppRoleId;
           
            if (updateUserDto.PasswordHash != null)
            {
               user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateUserDto.PasswordHash);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
