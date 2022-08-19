using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            string username = User.Identity.Name;
            string mail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();

            int writerId = writerManager.WriterIdBySession(mail);
            var writer = writerManager.GetWriterAboutById(writerId);

           

            return View(writer);

        }
    }
}
