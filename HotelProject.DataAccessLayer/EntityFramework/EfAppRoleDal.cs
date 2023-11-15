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
    public class EfAppRoleDal : GenericRepository<AppRole>, IAppRoleDal
    {
        public EfAppRoleDal(Context context) : base(context)
        {
        }
    }
}
