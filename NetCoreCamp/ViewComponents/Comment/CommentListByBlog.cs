using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.ViewComponents.Comment
{
    public class CommentListByBlog:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var items = commentManager.GetListById(id);
            return View(items);

        }
    }
}
