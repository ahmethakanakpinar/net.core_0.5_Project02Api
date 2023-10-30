using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class _LayoutController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
           return PartialView();
        }
        public PartialViewResult NavPartial() 
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial() 
        {
            return PartialView();
        }
    }
}
