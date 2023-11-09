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
    public class EfContactCategoryDal : GenericRepository<ContactCategory>, IContactCategoryDal
    {
        public EfContactCategoryDal(Context context) : base(context)
        {
        }
    }
}
