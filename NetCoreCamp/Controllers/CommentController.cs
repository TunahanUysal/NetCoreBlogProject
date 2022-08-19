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
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CommentAdd()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CommentAdd(Comment comment )
        {
            comment.BlogId = 1;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            commentManager.EntityAdd(comment);
            return PartialView();
        }
    }
}
