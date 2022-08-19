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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void EntityAdd(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public void EntityDelete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public void EntityUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetListAll();
        }

        public List<Writer> GetWriterAboutById(int id)
        {
            return _writerDal.ListByQuery(x => x.WriterId==id);
        }

        public Writer GetWriterByConfirm(Writer writer)
        {
            return _writerDal.GetWriterByLogin(writer);

        }

        public int WriterIdBySession(string mail)
        {
            return _writerDal.GetWriterIdByLogin(mail);
        }
    }
}
