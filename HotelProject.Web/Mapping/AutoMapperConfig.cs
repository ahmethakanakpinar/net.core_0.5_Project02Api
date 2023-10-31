using AutoMapper;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.AboutDto;
using HotelProject.Web.Dtos.LoginDto;
using HotelProject.Web.Dtos.RegisterDto;
using HotelProject.Web.Dtos.RoomDto;
using HotelProject.Web.Dtos.ServiceDto;
using HotelProject.Web.Dtos.TestimonialDto;

namespace HotelProject.Web.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<RegisterUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
        }
    }
}
