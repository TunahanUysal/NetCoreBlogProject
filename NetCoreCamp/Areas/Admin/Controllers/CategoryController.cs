using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
       
        public IActionResult CategoryIndex(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 3);

            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);
            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.EntityAdd(category);
                return RedirectToAction("CategoryIndex", "Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        public IActionResult DeleteCategory(int id)
        {
            var data = categoryManager.GetById(id);
            categoryManager.EntityDelete(data);
            return RedirectToAction("CategoryIndex", "Category");


        }
        public IActionResult ExportExcelFile()
        {
            using(var workbook=new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Kategori Listesi");
                worksheet.Cell(1, 1).Value = "Kategori Id";
                worksheet.Cell(1, 2).Value = "Kategori Adı";

                int categoryRow = 2;
                foreach (var item in categoryManager.CategoryListDropdown())
                {
                    worksheet.Cell(categoryRow, 1).Value = item.Value;
                    worksheet.Cell(categoryRow, 2).Value = item.Text;
                    categoryRow++;
                }

                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "	application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma.xlsx");
                }

            }

        }
    }
}
