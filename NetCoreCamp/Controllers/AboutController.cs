using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        public IActionResult AboutIndex()
        {
            var items = aboutManager.GetList();
            return View(items);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
