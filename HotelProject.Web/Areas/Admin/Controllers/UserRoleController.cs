using AutoMapper;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.Web.Dtos.UserRoleDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class UserRoleController : Controller
    {
        private readonly IAppRoleService _roleService;
        private readonly IMapper _mapper;

        public UserRoleController(IAppRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roledata = _roleService.TGetList();
            var values = _mapper.Map<List<ResultUserRoleDto>>(roledata);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddUserRole()
        {
            return View();
        }
    }
}
