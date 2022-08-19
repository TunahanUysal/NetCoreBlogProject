using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository()); 
        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult WriterList()
        {
            var jsonDatas = JsonConvert.SerializeObject(writerManager.GetList());
            return Json(jsonDatas);


        }
        public IActionResult WriterGetById(int writerid)
        {
            var data = writerManager.GetById(writerid);
            var jsonData = JsonConvert.SerializeObject(data);
            return Json(jsonData);
        }

        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            writer.WriterStatus = true;
            writerManager.EntityAdd(writer);
            var data = JsonConvert.SerializeObject(writer);
            return Json(data);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writerManager.GetById(id);
            writerManager.EntityDelete(writer);
            return Json(writer);
        }
        [HttpPost]
        public IActionResult UpdateWriter(Writer writer)
        {
            var data = writerManager.GetList().Where(x => x.WriterId == writer.WriterId).FirstOrDefault();
            writer.WriterStatus = true;
            data.WriterName = writer.WriterName;
            data.WriterMail = writer.WriterMail;
            data.WriterPassword = writer.WriterPassword;
            data.WriterImage = writer.WriterImage;
            data.WriterAbout = writer.WriterAbout;
           
            writerManager.EntityUpdate(data);
            var jsonObject = JsonConvert.SerializeObject(data);
            return Json(jsonObject);

            
        }
    }
}
