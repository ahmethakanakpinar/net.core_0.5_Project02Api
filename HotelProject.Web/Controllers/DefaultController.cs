using HotelProject.Web.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SubscribePartial() 
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SubscribePartial(CreateSubscribeDto createSubscribeDto) 
        {
            return View();
        }
    }
}
