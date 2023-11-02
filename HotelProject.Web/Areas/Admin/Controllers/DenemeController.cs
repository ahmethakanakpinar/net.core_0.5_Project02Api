using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
