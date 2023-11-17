using HotelProject.Web.Dtos.StaffDto;
using HotelProject.Web.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listAll = 0)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Testimonial");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (listAll != 0)
                {
                    var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData).Take(listAll).ToList();
                    return View(values);
                }
                else
                {
                    var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                    return View(values);
                }
              
            }
            return View();
        }
    }
}
