using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
       
        public void Delete(T entity)
        {
            using var context = new Context();
            
            context.Remove(entity);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();
            if (filter == null)
                return context.Set<T>().Count();
            else
                return context.Set<T>().Where(filter).Count();
        }

        public List<T> GetListAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {

            using var context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        public List<T> ListByQuery(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();
            return context.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {

            using var context = new Context();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
