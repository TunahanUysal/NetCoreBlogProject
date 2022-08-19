using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        [Area("Admin")]
        [AllowAnonymous]
        public IActionResult WidgetIndex()
        {
            return View();
        }
    }
}
