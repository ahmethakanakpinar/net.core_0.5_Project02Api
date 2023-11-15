﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer
{
    public class AppRole : IdentityRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> users { get; set; }
    }
}
