using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Comment
{
    public class CommentCountByWriter:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke()
        {
            int count = commentManager.CountOfCommnetsByWriter(1);
            ViewBag.commentcount = count;
            return View();
        }
    }
}
