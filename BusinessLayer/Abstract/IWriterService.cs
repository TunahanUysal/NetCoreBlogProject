using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface  IWriterService:IGenericService<Writer>
    {
       
        Writer GetWriterByConfirm(Writer writer);
        List<Writer> GetWriterAboutById(int id);
        int WriterIdBySession(string mail);


    }
}
