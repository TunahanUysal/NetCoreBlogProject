using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class ErrorPageController : Controller
    {
        [HttpGet]
        public IActionResult Error404(int code)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Error404()
        {
            return RedirectToAction("BlogIndex", "Blog");
        }
    }
}
