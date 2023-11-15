using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void TDelete(AppRole t)
        {
            _appRoleDal.Delete(t);
        }

        public AppRole TGetById(int id)
        {
            return _appRoleDal.GetByID(id);
        }

        public List<AppRole> TGetList()
        {
            return _appRoleDal.GetList();
        }

        public void TInsert(AppRole t)
        {
            _appRoleDal.Insert(t);
        }

        public void TUpdate(AppRole t)
        {
            _appRoleDal.Update(t);
        }
    }
}
