using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList() 
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult BookingGet(int id) 
        { 
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult BookingAdd(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpPut]
        public IActionResult BookingUpdate(Booking booking) 
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id) 
        {
            _bookingService.TDelete(_bookingService.TGetById(id));
            return Ok();
        }
    }
}
