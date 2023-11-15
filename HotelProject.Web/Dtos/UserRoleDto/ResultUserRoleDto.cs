using HotelProject.EntityLayer;

namespace HotelProject.Web.Dtos.UserRoleDto
{
    public class ResultUserRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> users { get; set; }

    }
}
