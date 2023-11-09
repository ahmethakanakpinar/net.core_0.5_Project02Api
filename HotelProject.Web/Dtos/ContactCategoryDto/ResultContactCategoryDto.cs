using HotelProject.EntityLayer;

namespace HotelProject.Web.Dtos.ContactCategoryDto
{
    public class ResultContactCategoryDto
    {
        public int ContactCategoryID { get; set; }
        public string ContactCategoryName { get; set; }
        public List<Contact> contacts { get; set; }
    }
}
