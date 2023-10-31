using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
