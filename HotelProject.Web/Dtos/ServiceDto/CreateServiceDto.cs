using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı Giriniz.")]
        [StringLength(50, ErrorMessage ="Hizmet Başlığı En Fazla 50 Karakter Olabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet Açıklaması Giriniz.")]
        public string Description { get; set; }
    }
}
