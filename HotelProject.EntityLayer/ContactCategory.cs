using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer
{
    public class ContactCategory
    {
        public int ContactCategoryID { get; set; }
        public string ContactCategoryName { get; set; }
        public List<Contact>? contacts { get; set; }
    }
}
