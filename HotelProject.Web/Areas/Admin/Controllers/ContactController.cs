using HotelProject.Web.Dtos.ContactDto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Api Eğitim Kurs", "egitimiciniletisim@gmail.com");
                    mimeMessage.From.Add(mailboxAddressFrom);
                    MailboxAddress mailboxAddressTo = new MailboxAddress(sendMessageDto.ReceiverName, sendMessageDto.Receiver);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = sendMessageDto.MessageContent;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = sendMessageDto.Subject;

                    SmtpClient clientmail = new SmtpClient();
                    clientmail.Connect("smtp.gmail.com", 587, false);
                    clientmail.Authenticate("egitimiciniletisim@gmail.com", "buhtlrcbetrrdzqq");
                    clientmail.Send(mimeMessage);
                    clientmail.Disconnect(true);
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
