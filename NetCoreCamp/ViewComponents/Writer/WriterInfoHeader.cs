using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Writer
{
    public class WriterInfoHeader:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        
        public IViewComponentResult Invoke()
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            int id = writerManager.WriterIdBySession(mail);
            var values = writerManager.GetWriterAboutById(id);
            return View(values);
        }

    }
}
