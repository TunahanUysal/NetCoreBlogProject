using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        AdminManager adminManager = new AdminManager(new EFAdminRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.name = adminManager.GetList().Where(x => x.AdminId == 1).Select(y => y.AdminName).FirstOrDefault();
            ViewBag.image= adminManager.GetList().Where(x => x.AdminId == 1).Select(y => y.AdminImage).FirstOrDefault();
            ViewBag.description= adminManager.GetList().Where(x => x.AdminId == 1).Select(y => y.AdminShortDescription).FirstOrDefault();
            
            return View();
        }
    }
}
