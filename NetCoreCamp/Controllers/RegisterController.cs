using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    public class RegisterController : Controller
    {
       
        WriterManager writermanager = new WriterManager(new EFWriterRepository());
        WriterValidator validations = new WriterValidator();
        [HttpGet]
        public IActionResult RegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterIndex(Writer writer)
        {
            ValidationResult result = validations.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                writermanager.EntityAdd(writer);
                return RedirectToAction("BlogIndex", "Blog");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View();
            }
            
        }
    }
}
