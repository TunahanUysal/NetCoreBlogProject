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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void EntityAdd(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void EntityDelete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }
    }
}
