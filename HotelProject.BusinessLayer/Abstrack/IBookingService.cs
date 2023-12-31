﻿using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstrack
{
    public interface IBookingService : IGenericService<Booking>
    {
        public void TApproveBookingUpdate(int id);
    }
}
