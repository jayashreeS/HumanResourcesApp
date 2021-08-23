using HumanResourcesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HumanResourcesApp.Data
{
 
        public class HRDataContext : DbContext
        {

            public HRDataContext() : base("HRDataContext")
            {
            }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Department> Departments { get; set; }
            
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
}