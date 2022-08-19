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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void EntityAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void EntityDelete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void EntityUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetListById(int id)
        {
           return  _commentDal.ListByQuery(x => x.BlogId == id);
           
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetListAll();
        }

        public int CountOfCommnetsByWriter(int id)
        {
           return  _commentDal.CommentCountByWriterInfo(id);
        }

        public int GetCountEntity()
        {
            return _commentDal.GetCount();
        }
    }
}
