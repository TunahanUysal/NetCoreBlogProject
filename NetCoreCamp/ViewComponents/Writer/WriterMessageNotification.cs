using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        public IViewComponentResult Invoke()
        {

            int id = 1;
            var values = message2Manager.GetInboxListByWriterId(id);
            return View(values);
        }
    }
}
