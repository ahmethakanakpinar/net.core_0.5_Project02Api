using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? Sender { get; set; }
        public string? SenderName { get; set; }
        public string? Receiver { get; set; }
        public string? ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
        public int ContactCategoryID { get; set; }
        public ContactCategory? ContactCategory { get; set; }

    }
}
