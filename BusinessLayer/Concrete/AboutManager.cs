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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void EntityAdd(About entity)
        {
            throw new NotImplementedException();
        }

        public void EntityDelete(About entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(About entity)
        {
            throw new NotImplementedException();
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.GetListAll();
        }
    }
}
