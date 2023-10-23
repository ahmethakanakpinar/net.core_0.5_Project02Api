using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult StaffGet(int id) 
        {
            var value = _staffService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult StaffAdd(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpPut]
        public IActionResult StaffUpdate(Staff staff)
        { 
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpDelete]
        public IActionResult StaffDelete(int id)
        {
            _staffService.TDelete(_staffService.TGetById(id));
            return Ok();
        }
    }
}
