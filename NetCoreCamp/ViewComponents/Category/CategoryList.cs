using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Category
{
    public class CategoryList:ViewComponent

    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        
        public IViewComponentResult Invoke()
        {

            var categorylist = categoryManager.GetList();
            
         
            return View(categorylist);

        }
    }
}
