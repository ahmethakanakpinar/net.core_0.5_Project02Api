using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Trailer
{
    public class TrailerList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
