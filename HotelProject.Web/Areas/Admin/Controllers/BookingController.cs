using HotelProject.Web.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Booking");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddBooking()
        { 
            return View(); 
        }
    }
}
