using HotelProject.EntityLayer;

namespace HotelProject.Web.Dtos.UserDto
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public int AppRoleId { get; set; }
    }
}
