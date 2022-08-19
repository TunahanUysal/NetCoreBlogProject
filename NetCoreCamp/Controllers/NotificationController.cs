using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EFNotificationRepository());

        [AllowAnonymous]
        public IActionResult NotificationIndex()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
