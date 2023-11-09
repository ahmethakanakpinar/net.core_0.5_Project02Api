using HotelProject.BusinessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCategoryController : ControllerBase
    {
        private readonly IContactCategoryService _contactCategoryService;

        public ContactCategoryController(IContactCategoryService contactCategoryService)
        {
            _contactCategoryService = contactCategoryService;
        }
        [HttpGet]
        public IActionResult ContactCategoryList()
        {
            var values = _contactCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult ContactCategoryGet(int id) 
        {
            var value = _contactCategoryService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult ContactCategoryAdd(ContactCategory contactCategory)
        {
            _contactCategoryService.TInsert(contactCategory);
            return Ok();
        }
        [HttpPut]
        public IActionResult ContactCategoryUpdate(ContactCategory contactCategory)
        {
            _contactCategoryService.TUpdate(contactCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult ContactCategoryDelete(int id)
        {
            var value = _contactCategoryService.TGetById(id);
            _contactCategoryService.TDelete(value);
            return Ok();
        }
    }
}
