using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.blogName = blogManager.GetList().OrderByDescending(x => x.BlogId).Select(y => y.BlogTitle).Take(1).FirstOrDefault();
            int writerId = blogManager.GetList().OrderByDescending(x => x.BlogId).Select(y => y.WriterId).Take(1).FirstOrDefault();
            ViewBag.writerName = writerManager.GetList().Where(x => x.WriterId == writerId).Select(y => y.WriterName).FirstOrDefault();
            return View();
        }
    }
}
