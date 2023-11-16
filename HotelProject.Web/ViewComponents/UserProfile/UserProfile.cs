using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.UserProfile
{
    public class UserProfile : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public UserProfile(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var me = await _userManager.FindByNameAsync(User.Identity.Name);
            ResultProfileDto result = new ResultProfileDto();
            result.Name = me.Name;
            result.Surname = me.Surname;
            result.Email = me.Email;
            result.ImageUrl = me.ImageUrl;
            result.UserName = me.UserName;
            result.PhoneNumber = me.PhoneNumber;
            return View(result);
        }
    }
}
