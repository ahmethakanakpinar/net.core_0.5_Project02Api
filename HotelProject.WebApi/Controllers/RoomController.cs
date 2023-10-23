using HotelProject.BusinessLayer.Abstrack;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult RoomGet(int id)
        {
            var value = _roomService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult RoomAdd(Room room)
        {
            _roomService.TInsert(room);
            return Ok();
        }
        [HttpPut]
        public IActionResult RoomUpdate(Room room) 
        {
            _roomService.TUpdate(room);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult RoomDelete(int id)
        {
            var value = _roomService.TGetById(id);
            _roomService.TDelete(value);
            return Ok();
        }
    }
}
