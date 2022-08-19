 using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal; 
        

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public List<SelectListItem> CategoryListDropdown()
        {
            List<SelectListItem> selectLists = (from x in _categoryDal.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }
                                              ).ToList();
            return selectLists;
        }

        public void EntityAdd(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void EntityDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void EntityUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public int GetCountEntity()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }


        
    }
}
