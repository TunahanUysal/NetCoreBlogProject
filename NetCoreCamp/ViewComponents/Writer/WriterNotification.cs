using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetList().Where(y => y.NotificationStatus == true).OrderByDescending(X=>X.NotificationID).Take(5).ToList();
            return View(values);
        }
    }
}
