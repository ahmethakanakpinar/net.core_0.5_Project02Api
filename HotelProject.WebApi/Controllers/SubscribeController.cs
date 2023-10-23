using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }
        [HttpGet]
        public IActionResult SubscribeList() 
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult SubscribeGet(int id) 
        {
            var value = _subscribeService.TGetById(id);
            return Ok(value);   
        }
        [HttpPost]
        public IActionResult SubscribeAdd(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok();
        }
        [HttpPut]
        public IActionResult SubscribeUpdate(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult SubscribeDelete(int id) 
        {
            _subscribeService.TDelete(_subscribeService.TGetById(id));
            return Ok();
        }
    }
}
