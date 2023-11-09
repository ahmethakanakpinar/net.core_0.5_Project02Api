﻿using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstrack
{
    public interface IContactDal : IGenericDal<Contact>
    {
        public int GetReceiverMessage();
        public int GetSenderMessage();
    }
}
