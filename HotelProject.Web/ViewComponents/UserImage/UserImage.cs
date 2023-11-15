using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.UserImage
{
    public class UserImage : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public UserImage(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.ImageUrl;
            return View();
        }
    }
}
