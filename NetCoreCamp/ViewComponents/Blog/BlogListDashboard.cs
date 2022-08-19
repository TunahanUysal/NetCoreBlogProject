﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var data = blogManager.GetBlogListWithCategory();
            return View(data);

        }
    }
}
