using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class _AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
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
        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial() 
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial() 
        {
            return PartialView();
        }
    }
}
