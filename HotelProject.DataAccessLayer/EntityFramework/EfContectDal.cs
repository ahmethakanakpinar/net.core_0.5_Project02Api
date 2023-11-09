using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfContectDal : GenericRepository<Contact>, IContactDal
    {
        public EfContectDal(Context context) : base(context)
        {
        }

        public int GetReceiverMessage()
        {
            var context = new Context();
            return context.Contacts.Where(c => c.Receiver == "admin@gmail.com").Count();
        }

        public int GetSenderMessage()
        {
            var context = new Context();
            return context.Contacts.Where(c => c.Sender == "admin@gmail.com").Count();
        }
    }
}
