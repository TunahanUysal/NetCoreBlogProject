using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void EntityAdd(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void EntityDelete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            return _contactDal.GetCount();
        }

        public List<Contact> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
