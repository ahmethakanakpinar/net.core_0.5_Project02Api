using HotelProject.Web.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReceiverMessage()
        {
            var adminemail = "admin@gmail.com";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allContacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                var filteredContacts = allContacts.Where(contact => contact.Receiver == adminemail).ToList();

                return View(filteredContacts);
            }
            return View();
        }
        public async Task<IActionResult> SenderMessage()
        {
            var adminemail = "admin@gmail.com";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allContacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var filteredContacts = allContacts.Where(contact => contact.Sender == adminemail).ToList();
                return View(filteredContacts);
            }
            return View();
        }
    }
}
