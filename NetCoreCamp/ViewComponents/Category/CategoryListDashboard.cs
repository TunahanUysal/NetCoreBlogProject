using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var items = categoryManager.GetList();
            return View(items);
        }
    }
}
