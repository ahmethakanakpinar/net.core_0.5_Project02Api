using System.ComponentModel.DataAnnotations;

namespace HotelProject.Web.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        [Required()]
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
