using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
