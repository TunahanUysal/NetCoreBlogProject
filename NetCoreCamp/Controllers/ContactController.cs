using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        [HttpGet]
        public IActionResult ContactIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactIndex(Contact contact )
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            contactManager.EntityAdd(contact);
            return RedirectToAction("BlogIndex","Blog");
        }
    }
}
