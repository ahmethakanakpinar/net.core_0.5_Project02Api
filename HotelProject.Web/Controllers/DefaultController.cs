using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
