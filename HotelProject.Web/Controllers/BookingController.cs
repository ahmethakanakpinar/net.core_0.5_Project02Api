using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
