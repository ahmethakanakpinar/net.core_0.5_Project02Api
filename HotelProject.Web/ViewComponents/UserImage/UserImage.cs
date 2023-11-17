using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.ContactDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.UserImage
{
    public class UserImage : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserImage(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var adminemail = "admin@gmail.com";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact/GetReceivers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var allContacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var filteredContactsReceiver = allContacts.Where(contact => contact.Receiver == adminemail).ToList();
                ViewBag.receiverMessageCount = filteredContactsReceiver.Count;
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.ImageUrl;
            return View();
        }
    }
}
