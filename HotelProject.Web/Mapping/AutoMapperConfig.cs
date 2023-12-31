﻿using AutoMapper;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.AboutDto;
using HotelProject.Web.Dtos.BookingDto;
using HotelProject.Web.Dtos.ContactCategoryDto;
using HotelProject.Web.Dtos.ContactDto;
using HotelProject.Web.Dtos.LoginDto;
using HotelProject.Web.Dtos.RegisterDto;
using HotelProject.Web.Dtos.RoomDto;
using HotelProject.Web.Dtos.ServiceDto;
using HotelProject.Web.Dtos.StaffDto;
using HotelProject.Web.Dtos.SubscribeDto;
using HotelProject.Web.Dtos.TestimonialDto;
using HotelProject.Web.Dtos.UserDto;
using HotelProject.Web.Dtos.UserRoleDto;

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
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<ApproveBookingDto, Booking>().ReverseMap();
            CreateMap<SendMessageDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactCategoryDto, ContactCategory>().ReverseMap();
            CreateMap<ResultUserDto, AppUser>().ReverseMap();
            CreateMap<CreateUserDto, AppUser>().ReverseMap();
            CreateMap<UpdateUserDto, AppUser>().ReverseMap();
            CreateMap<ProfileUserDto, AppUser>().ReverseMap();
            CreateMap<ResultProfileDto, AppUser>().ReverseMap();
            CreateMap<UpdateUserSameUserRoleDto, AppUser>().ReverseMap();
            CreateMap<ResultUserRoleDto, AppRole>().ReverseMap();
            CreateMap<CreateUserRoleDto, AppRole>().ReverseMap();

        }
    }
}
