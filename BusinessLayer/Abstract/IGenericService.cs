using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface  IGenericService<T>
    {
        void EntityAdd(T entity);
        void EntityDelete(T entity);
        void EntityUpdate(T entity);
        List<T> GetList();
        T GetById(int id);
        int GetCountEntity();
    }
}
