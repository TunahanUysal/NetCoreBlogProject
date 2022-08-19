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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void EntityAdd(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void EntityDelete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetListAll();
        }
    }
}
