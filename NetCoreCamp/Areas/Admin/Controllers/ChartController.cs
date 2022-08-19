using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreCamp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        
        [AllowAnonymous]
        public IActionResult ChartIndex()
        {

            return View();
        }
        [AllowAnonymous]
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                blogcountofcategory = 15
            });
            list.Add(new CategoryModel
            {
                categoryname = "Yazılım",
                blogcountofcategory = 18
            });
            list.Add(new CategoryModel
            {
                categoryname = "Tiyatro",
                blogcountofcategory = 10
            });
            list.Add(new CategoryModel
            {
                categoryname = "Film",
                blogcountofcategory = 22
            });
            return Json(new {jsonlist=list });
            
        }
    }
}
