using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Staff
{
    public class StaffList:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
