using CoreBlogApiDemo.Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetListEmployee()
        {
            using(var item=new Context())
            {
                var values = item.Employees.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using(var item=new Context())
            {
                item.Employees.Add(employee);
                item.SaveChanges();
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using(var item=new Context())
            {
                var data = item.Employees.Find(id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using (var item = new Context())
            {
                var data = item.Employees.Find(id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    item.Employees.Remove(data);
                    item.SaveChanges();
                    return Ok();
                }

            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using(var item=new Context())
            {
                var data = item.Employees.Find(employee.EmployeeId);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.EmployeeName = employee.EmployeeName;
                    item.Employees.Update(data);
                    item.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
