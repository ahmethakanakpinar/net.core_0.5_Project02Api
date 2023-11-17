using HotelProject.Web.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Room
{
    public class RoomList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listAll = 0)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Room");
            if(responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if(listAll != 0)
                {
                    var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData).Take(listAll).ToList();
                    return View(values);
                }
                else
                {
                    var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
    }
}
