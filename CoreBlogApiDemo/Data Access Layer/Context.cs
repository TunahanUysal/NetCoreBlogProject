using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogApiDemo.Data_Access_Layer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("server=DESKTOP-KCTMQK7\\SQLEXPRESS;database=CoreBlogApiDb;integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
