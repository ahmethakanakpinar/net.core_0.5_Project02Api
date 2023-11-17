using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
