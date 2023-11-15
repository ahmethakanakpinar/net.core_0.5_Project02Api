using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.UserDto
{
    public class ProfileUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }

        public string? OldPasswordHash { get; set; }
        public string? PasswordHash { get; set; }
        [Compare("PasswordHash", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string? ConfirmPasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
