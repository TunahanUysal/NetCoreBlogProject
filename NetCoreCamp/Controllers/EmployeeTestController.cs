using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCamp.Controllers
{
    [AllowAnonymous]
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44345/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);

            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddEmployee(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent stringContent = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44345/api/Default", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "EmployeeTest");
            }
            else return View(class1);

        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44345/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonString);
                return View(values);
            }
            else return RedirectToAction("Index", "EmployeeTest");

        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            var stringContent = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44345/api/Default", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else return View(class1);


        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44345/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else return NotFound();
        }
    }

    public class Class1
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
