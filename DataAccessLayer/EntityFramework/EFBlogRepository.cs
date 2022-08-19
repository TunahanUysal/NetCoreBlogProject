using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public int BlogCountByWriter(int id)
        {
           using (var item=new Context())
            {
                return item.Blogs.Where(x => x.WriterId == id).Count();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using(var item=new Context())
            {
                return item.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryName(int id)
        {
            using (var item = new Context())
            {
                return item.Blogs.Include(x => x.Category).Where(y=>y.WriterId==id).ToList();
            }
        }

        public int GetWriterIdByLogin(string mail)
        {
            using (var item = new Context())
            {
                return item.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            }
        }
    }
}
