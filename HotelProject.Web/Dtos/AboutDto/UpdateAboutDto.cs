namespace HotelProject.Web.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string RoomCount { get; set; }
        public string StaffCount { get; set; }
        public string ClientCount { get; set; }
    }
}
