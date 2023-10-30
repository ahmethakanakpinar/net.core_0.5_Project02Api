using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.Web.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace HotelProject.Web.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutList(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var aboutData = _aboutService.TGetList();
            var values = _mapper.Map<List<ResultAboutDto>>(aboutData);
            return View(values);
        }
    }
}
