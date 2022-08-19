using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public int BlogCountByWriterInfo(int id)
        {
            return _blogDal.BlogCountByWriter(id);
        }

        public void EntityAdd(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void EntityDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public void EntityUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.ListByQuery(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListByCategoryNameBL(int id)
        {
            return _blogDal.GetListWithCategoryName(id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.ListByQuery(x => x.WriterId == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public int GetCountEntity()
        {
            return _blogDal.GetCount();
        }

        public List<Blog> GetLastThreeBlogs()
        {
            return _blogDal.GetListAll().TakeLast(3).ToList();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public int WriterIdBySession(string mail)
        {
            return _blogDal.GetWriterIdByLogin(mail);
        }
    }
}
