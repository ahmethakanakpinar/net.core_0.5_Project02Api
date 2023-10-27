using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş geçilemez!")]
        public string PasswordHash { get; set; }
    }
}
