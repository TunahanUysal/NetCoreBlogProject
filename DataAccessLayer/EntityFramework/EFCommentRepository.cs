using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public int CommentCountByWriterInfo(int id)
        {
            using(var item=new Context())
            {
                var query = (from x in item.Comments
                             join y in item.Blogs
                             on x.BlogId equals y.BlogId
                             select y


                           ).ToList();
                return query.Count(x => x.WriterId == id);
            }
        }
    }
}
