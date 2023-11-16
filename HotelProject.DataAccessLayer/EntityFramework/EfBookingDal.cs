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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void ApproveBookingUpdate(int id)
        {
            var context = new Context();
            var data = context.Bookings.Where(c => c.BookingID == id).FirstOrDefault();
            if(data.Status == "Onay Bekleniyor")
            {
                data.Status = "Onaylandı";
            }
            else
            {
                data.Status = "Onay Bekleniyor";
            }
            context.SaveChanges();
        }
    }
}
