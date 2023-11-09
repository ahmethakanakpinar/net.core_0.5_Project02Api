using HotelProject.Web.Dtos.ContactCategoryDto;
using HotelProject.Web.Dtos.ContactDto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/ContactCategory");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultContactCategoryDto>>(jsonData);
                List<SelectListItem> values = (from x in data select new SelectListItem
                {
                    Text = x.ContactCategoryName,
                    Value = x.ContactCategoryID.ToString()
                }).ToList();
                ViewBag.ContactCategory = values;
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if(ModelState.IsValid) 
            {
                createContactDto.Receiver = "admin@gmail.com";
                createContactDto.ReceiverName = "Ahmet Hakan";
                createContactDto.Date = DateTime.Now;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createContactDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7113/api/Contact", stringContent);
                if(responseMessage.IsSuccessStatusCode)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Api Eğitim Kurs", "egitimiciniletisim@gmail.com");
                    mimeMessage.From.Add(mailboxAddressFrom);
                    MailboxAddress mailboxAddressTo = new MailboxAddress(createContactDto.ReceiverName, createContactDto.Receiver);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = createContactDto.MessageContent;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = createContactDto.Subject;

                    SmtpClient clientmail = new SmtpClient();
                    clientmail.Connect("smtp.gmail.com", 587, false);
                    clientmail.Authenticate("egitimiciniletisim@gmail.com", "");
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
    }
}
