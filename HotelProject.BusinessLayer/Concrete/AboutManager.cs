﻿using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TInsert(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}