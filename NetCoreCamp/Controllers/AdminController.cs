using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
