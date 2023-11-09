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
    public class ContactCategoryManager : IContactCategoryService
    {
        private readonly IContactCategoryDal _contactCategoryDal;

        public ContactCategoryManager(IContactCategoryDal contactCategoryDal)
        {
            _contactCategoryDal = contactCategoryDal;
        }

        public void TDelete(ContactCategory t)
        {
            _contactCategoryDal.Delete(t);
        }

        public ContactCategory TGetById(int id)
        {
            return _contactCategoryDal.GetByID(id);
        }

        public List<ContactCategory> TGetList()
        {
            return _contactCategoryDal.GetList();
        }

        public void TInsert(ContactCategory t)
        {
            _contactCategoryDal.Insert(t);
        }

        public void TUpdate(ContactCategory t)
        {
            _contactCategoryDal.Update(t);
        }
    }
}
