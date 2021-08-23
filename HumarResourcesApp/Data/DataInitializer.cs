using HumanResourcesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesApp.Data
{
    public class DataInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<HRDataContext>
    {
        protected override void Seed(HRDataContext context)
        {
            var students = new List<Employee>
            {
            new Employee{FirstName="Srikanth",LastName="Bugga",DateOfBirth=DateTime.Parse("1988-07-10"),Address="Kukatpally",City="Hyderabad",DepartmentId=11},
            new Employee{FirstName="Pavan",LastName="Kathula",DateOfBirth=DateTime.Parse("1987-10-10"),Address="Kukatpally",City="Hyderabad",DepartmentId=10},
            new Employee{FirstName="Archana",LastName="Singarapu",DateOfBirth=DateTime.Parse("1990-07-10"),Address="Kukatpally",City="Hyderabad",DepartmentId=12},
            new Employee{FirstName="Shravanti",LastName="Visinigiri",DateOfBirth=DateTime.Parse("1989-07-10"),Address="Kukatpally",City="Hyderabad",DepartmentId=13}
            

            };

            students.ForEach(emp => context.Employees.Add(emp));
            context.SaveChanges();
            var departments = new List<Department>
            {
            new Department{DepartmentId=10,Name="HR"},
            new Department{DepartmentId=11,Name="Operations"},
            new Department{DepartmentId=12,Name="Finance"},
            new Department{DepartmentId=13,Name="Procurement"},
            new Department{DepartmentId=14,Name="Support"}
            
            };
            departments.ForEach(dep => context.Departments.Add(dep));
            context.SaveChanges();
         
        }
    }
}