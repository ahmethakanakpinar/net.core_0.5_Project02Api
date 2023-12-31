﻿using HotelProject.EntityLayer;

namespace HotelProject.Web.Dtos.UserDto
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public int AppRoleId { get; set; }
        public AppRole? AppRole { get; set; }

    }
}
