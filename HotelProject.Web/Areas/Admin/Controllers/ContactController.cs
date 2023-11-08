using HotelProject.Web.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            ViewBag.Source = "receiver";
            var adminemail = "admin@gmail.com";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allContacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

                var filteredContacts = allContacts.Where(contact => contact.Receiver == adminemail).ToList();
                ViewBag.receiverMessageCount = filteredContacts.Count;
                return View(filteredContacts);
            }
            return View();
        }
        public async Task<IActionResult> SenderMessage()
        {
            ViewBag.Source = "sender";
            var adminemail = "admin@gmail.com";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allContacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var filteredContacts = allContacts.Where(contact => contact.Sender == adminemail).ToList();
                ViewBag.senderMessageCount = filteredContacts.Count;
                return View(filteredContacts);
            }
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDto sendMessageDto)
        {
            sendMessageDto.Sender = "admin@gmail.com";
            sendMessageDto.SenderName = "Ahmet Hakan Akpınar";
            sendMessageDto.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(sendMessageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7113/api/Contact", stringContent);
                if(responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("SenderMessage");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
        
        public async Task<IActionResult> ShowDetailMessage(int contactId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7113/api/Contact/{contactId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
