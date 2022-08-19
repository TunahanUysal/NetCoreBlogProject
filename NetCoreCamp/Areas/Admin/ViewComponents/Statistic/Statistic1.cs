using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetCoreCamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        CommentManager commentManager = new CommentManager(new EFCommentRepository());

        public IViewComponentResult Invoke()
        {
            int countOfBlogs = blogManager.GetCountEntity();
            int countOfContacts = contactManager.GetCountEntity();
            int countOfComments = commentManager.GetCountEntity();
            ViewBag.blogcount = countOfBlogs;
            ViewBag.contactcount = countOfContacts;
            ViewBag.commentcount = countOfComments;
            string api= "f169d16819269b15bcbd7b6bb593dc2e";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
           
        }
    }
}
