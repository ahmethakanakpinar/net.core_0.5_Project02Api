using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
