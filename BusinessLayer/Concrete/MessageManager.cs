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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void EntityAdd(Message entity)
        {
            throw new NotImplementedException();
        }

        public void EntityDelete(Message entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            throw new NotImplementedException();

        }

        public List<Message> GetListByMail(string mail)
        {
            return _messageDal.ListByQuery(x => x.Receiver == mail);
        }
    }
}
