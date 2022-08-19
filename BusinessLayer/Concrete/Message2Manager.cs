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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void EntityAdd(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void EntityDelete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetInboxListByWriterId(int id)
        {
            return _message2Dal.GetInboxListByWriterInfo(id);
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }
    }
}
