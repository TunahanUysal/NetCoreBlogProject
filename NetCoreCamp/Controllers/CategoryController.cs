using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index()
        {
            var list = categoryManager.GetList();
            return View(list);
        }
    }
}
