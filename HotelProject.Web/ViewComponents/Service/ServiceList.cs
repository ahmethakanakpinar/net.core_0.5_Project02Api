using HotelProject.Web.Dtos.RoomDto;
using HotelProject.Web.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listAll = 0)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Service");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                if (listAll != 0)
                {
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(JsonData).Take(listAll).ToList();
                    return View(values);
                }
                else
                {
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(JsonData);
                    return View(values);
                }
            }
            return View();
        }
    }
}
