﻿using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstrack
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        public void ApproveBookingUpdate(int id);
    }
}
