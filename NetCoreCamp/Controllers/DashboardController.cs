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
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());

       [Authorize]

        public IActionResult DashboardIndex()
        {
            ViewBag.blogcount = blogManager.BlogCountByWriterInfo(1);
            return View();
        }
    }
}
