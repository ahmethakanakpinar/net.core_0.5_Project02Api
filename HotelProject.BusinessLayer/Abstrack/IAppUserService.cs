﻿using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstrack
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        public List<AppUser> TGetAppRole();
        public List<AppUser> TGetAppUserSameAppRole(int id);
    }
}
