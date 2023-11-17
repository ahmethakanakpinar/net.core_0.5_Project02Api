using HotelProject.Web.Dtos.ServiceDto;
using HotelProject.Web.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Staff
{
    public class StaffList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listAll = 0)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Staff");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                if (listAll != 0)
                {
                    var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData).Take(listAll).ToList();
                    return View(values);
                }
                else
                {
                    var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                    return View(values);
                }
             
            }
            return View();
        }
    }
}
