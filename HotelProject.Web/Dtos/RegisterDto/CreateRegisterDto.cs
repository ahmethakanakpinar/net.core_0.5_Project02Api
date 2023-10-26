using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.RegisterDto
{
    public class CreateRegisterDto 
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Adınız Boş Geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyadınız Boş Geçilemez!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Mail Adresiniz Boş Geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        public string PasswordHash { get; set; }
    }
}
