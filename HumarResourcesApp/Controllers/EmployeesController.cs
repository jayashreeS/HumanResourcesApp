using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanResourcesApp.Data;
using HumanResourcesApp.Models;

namespace HumarResourcesApp.Controllers
{
    public class EmployeesController : Controller
    {
        private HRDataContext db = new HRDataContext();

        #region Index region

        // GET: Employees
        public ActionResult Index(string sortOrder)
        {
            // Viewbag
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "Id_desc" : "Id";

            var Employees1 = from emp in db.Employees
                             select emp;
            switch (sortOrder)
            {
                case "name_desc":
                    Employees1 = Employees1.OrderByDescending(s => s.FirstName);
                    break;
                case "Id":
                    Employees1 = Employees1.OrderBy(s => s.EmployeeNumber);
                    break;
                case "Id_desc":
                    Employees1 = Employees1.OrderByDescending(s => s.EmployeeNumber);
                    break;
                default:
                    Employees1 = Employees1.OrderBy(s => s.FirstName);
                    break;
            }
            return View(db.Employees.ToList());
        }

#endregion

        #region Details region
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        #endregion

        #region Create region
        // GET: Employees/Create
        public ActionResult Create()
        {
            GetDepartments();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeNumber,DateOfBirth,DepartmentId,FirstName,LastName,Address,City")] Employee employee)
        {
            GetDepartments();

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        #endregion

        #region Edit region
        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            GetDepartments();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeNumber,DateOfBirth,DepartmentId,FirstName,LastName,Address,City")] Employee employee)
        {
            GetDepartments();
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        #endregion

        #region Delete region
        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Internal methods
        /// <summary>
        /// Gets the list of departments
        /// </summary>
        public void GetDepartments()
        {
            ViewBag.DepartmentList = new SelectList(db.Departments.ToList(), "DepartmentId", "Name");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}
