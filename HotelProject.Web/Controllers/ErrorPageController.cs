using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ErrorPageController : Controller
    {
        [AllowAnonymous]
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult Error403()
        {
            return View();
        }
    }
}
