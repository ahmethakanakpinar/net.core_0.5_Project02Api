using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.UserDto
{
    public class ResultProfileDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
