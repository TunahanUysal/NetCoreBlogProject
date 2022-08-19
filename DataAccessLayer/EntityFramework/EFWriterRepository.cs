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
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public Writer GetWriterByLogin(Writer writer)
        {
           using(var item=new Context())
            {
                return item.Writers.FirstOrDefault(x=>x.WriterMail==writer.WriterMail && x.WriterPassword==writer.WriterPassword);
            }
        }

        public int GetWriterIdByLogin(string mail)
        {
           
            using(var item=new Context())
            {
                return item.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            }
        }
    }
}
