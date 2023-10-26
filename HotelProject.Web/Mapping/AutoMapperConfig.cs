using AutoMapper;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.RegisterDto;
using HotelProject.Web.Dtos.ServiceDto;

namespace HotelProject.Web.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateRegisterDto, AppUser>().ReverseMap();
        }
    }
}
