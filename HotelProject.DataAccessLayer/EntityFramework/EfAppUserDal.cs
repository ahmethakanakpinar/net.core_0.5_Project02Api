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
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public List<AppUser> GetAppRole()
        {
            var context = new Context();
            return context.Users.OfType<AppUser>().Include(c => c.AppRole).ToList();
            //return context.Users.Include(c => c.AppRole).ToList();
        }

        public List<AppUser> GetAppUserSameAppRole(int id)
        {
            using (var context = new Context())
            {
                var usersInRole = context.Users.OfType<AppUser>().Where(c => c.AppRoleId == id).ToList();
                return usersInRole;
            }
        }
    }
}
