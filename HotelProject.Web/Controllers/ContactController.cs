using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
