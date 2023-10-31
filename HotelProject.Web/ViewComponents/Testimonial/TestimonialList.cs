using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
