using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialController(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialDal.GetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialDal.GetByID(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult TestimonialAdd(Testimonial testimonial)
        {
            _testimonialDal.Insert(testimonial);
            return Ok();
        }
        [HttpPut]
        public IActionResult TestimonialUpdate(Testimonial testimonial) 
        { 
            _testimonialDal.Update(testimonial);
            return Ok();
        }
        [HttpDelete]
        public IActionResult TestimonialDelete(int id)
        {
            _testimonialDal.Delete(_testimonialDal.GetByID(id));
            return Ok();
        }
    }
}
