using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
