using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(Context context) : base(context)
        {
        }

        public int GetReceiverMessage()
        {
            var context = new Context();
            return context.Contacts.Where(c => c.Receiver == "admin@gmail.com").Count();
        }

        public List<Contact> GetReceivers()
        {
            var context = new Context();
            return context.Contacts.Include(c=> c.ContactCategory).ToList();
        }

        public int GetSenderMessage()
        {
            var context = new Context();
            return context.Contacts.Where(c => c.Sender == "admin@gmail.com").Count();
        }
       
    }
}
