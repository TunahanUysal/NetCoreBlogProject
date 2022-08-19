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
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void EntityAdd(Newsletter entity)
        {
             _newsletterDal.Insert(entity);
        }

        public void EntityDelete(Newsletter entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Newsletter entity)
        {
            throw new NotImplementedException();
        }

        public Newsletter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
