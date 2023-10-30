using AutoMapper;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.Web.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;
        private readonly IMapper _mapper;

        public AboutController(AboutManager aboutManager, IMapper mapper)
        {
            _aboutManager = aboutManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutManager.TGetList();
            var values = _mapper.Map<List<ResultAboutDto>>(aboutData);
            return View(values);
        }
    }
}
