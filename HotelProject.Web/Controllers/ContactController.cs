using HotelProject.Web.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if(ModelState.IsValid) 
            {
                createContactDto.Receiver = "ahmethakan.akpinar@tora.com.tr";
                createContactDto.ReceiverName = "Ahmet Hakan";
                createContactDto.Date = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createContactDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7113/api/Contact", stringContent);
                if(responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
