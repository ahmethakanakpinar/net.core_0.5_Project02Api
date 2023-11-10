using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult ContactGet(int id) 
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult ContactAdd(Contact contact) 
        {
            _contactService.TInsert(contact);
            return Ok();
        }
        [HttpPut]
        public IActionResult ContactUpdate(Contact contact) 
        {
            _contactService.TUpdate(contact);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok();
        }
        [HttpGet("GetReceiverMessage")]
        public IActionResult GetReceiverMessage()
        {
            return Ok(_contactService.TGetReceiverMessage());
        }
        [HttpGet("GetSenderMessage")]
        public IActionResult GetSenderMessage()
        {
            return Ok(_contactService.TGetSenderMessage());
        }
        [HttpGet("GetReceivers")]
        public IActionResult GetReceivers()
        {
            return Ok(_contactService.TGetReceivers());
        }
    }
}
