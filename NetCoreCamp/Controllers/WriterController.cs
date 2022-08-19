using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreCamp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        [AllowAnonymous]
        public IActionResult WriterIndex()
        {
            return View();
        }

        [AllowAnonymous]
        
        public PartialViewResult WriterSidebarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            int id = writerManager.WriterIdBySession(mail);
            var item = writerManager.GetById(id);
            return View(item);
        }
       
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                writer.WriterStatus = true;
                writerManager.EntityUpdate(writer);
                
                return RedirectToAction("DashboardIndex", "Dashboard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View();
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddImageProfile addImageProfile)
        {
            Writer writer = new Writer();
            if (addImageProfile.WriterImage != null)
            {
                var extension = Path.GetExtension(addImageProfile.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFile/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                addImageProfile.WriterImage.CopyTo(stream);
                writer.WriterImage = "/WriterImageFile/"+ newimagename;
            }
            writer.WriterName = addImageProfile.WriterName;
            writer.WriterMail = addImageProfile.WriterMail;
            writer.WriterPassword = addImageProfile.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = addImageProfile.WriterAbout;

            writerManager.EntityAdd(writer);

            return RedirectToAction("DashboardIndex", "Dashboard");
        }



    }
}
