using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
   
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        [AllowAnonymous]
        public IActionResult BlogIndex()
        {
            var blogs = blogManager.GetBlogListWithCategory();
            return View(blogs);
        }
        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {
            
            ViewBag.blogid = id;
            var blogdetails = blogManager.GetBlogById(id);
            return View(blogdetails);
        }
        public IActionResult BlogListByWriterInfo()
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            int writerId = blogManager.WriterIdBySession(mail);
           var data= blogManager.GetBlogListByCategoryNameBL(writerId);
           
           return View(data);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            var categorylist = categoryManager.CategoryListDropdown();
            ViewBag.listofcategory = categorylist;

            return View();

        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            int Id = blogManager.WriterIdBySession(mail);
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = Id;
                blogManager.EntityAdd(blog);
                return RedirectToAction("BlogListByWriterInfo", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
               
            }
            return View();


        }

        
        public IActionResult BlogDelete(int id)
        {
            var data = blogManager.GetById(id);
            blogManager.EntityDelete(data);

            return RedirectToAction("BlogListByWriterInfo", "Blog");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var categorylist = categoryManager.CategoryListDropdown();
            ViewBag.listofcategory = categorylist;
            var blogValue = blogManager.GetById(id);
            return View(blogValue);

        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            int Id = blogManager.WriterIdBySession(mail);
            blog.WriterId = Id;
            blogManager.EntityUpdate(blog);

            return RedirectToAction("BlogListByWriterInfo", "Blog");

        }
    }
}
