using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDemoUsingEntityFW.Models;

namespace MvcDemoUsingEntityFW.Controllers
{
    public class Employee_1Controller : Controller
    {
        private MvcSampleEntities1 db = new MvcSampleEntities1();

        // GET: Employee_1
        public ActionResult Index()
        {
            var employee_1 = db.Employee_1.Include(e => e.Department);
            return View(employee_1.ToList());
        }

        // GET: Employee_1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_1 employee_1 = db.Employee_1.Find(id);
            if (employee_1 == null)
            {
                return HttpNotFound();
            }
            return View(employee_1);
        }

        // GET: Employee_1/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Employee_1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee_1 employee_1)
        {
            if(string.IsNullOrEmpty(employee_1.Name))
            {

                ModelState.AddModelError("Name", "The Name field is required");
            }

            if (ModelState.IsValid)
            {
                db.Employee_1.Add(employee_1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee_1.DepartmentId);
            return View(employee_1);
        }

        // GET: Employee_1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_1 employee_1 = db.Employee_1.Find(id);
            if (employee_1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee_1.DepartmentId);
            return View(employee_1);
        }

        // POST: Employee_1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude ="Name")] Employee_1 employee)
        {
            Employee_1 employeeFromDb = db.Employee_1.Single(x => x.EmployeeId == employee.EmployeeId);

            employeeFromDb.Gender = employee.Gender;
            employeeFromDb.City = employee.City;
            employeeFromDb.DepartmentId = employee.DepartmentId;
            employee.Name = employeeFromDb.Name;

            if (ModelState.IsValid)
            {
                db.Entry(employeeFromDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employeeFromDb.DepartmentId);
            return View(employeeFromDb);
        }

        // GET: Employee_1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_1 employee_1 = db.Employee_1.Find(id);
            if (employee_1 == null)
            {
                return HttpNotFound();
            }
            return View(employee_1);
        }

        // POST: Employee_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_1 employee_1 = db.Employee_1.Find(id);
            db.Employee_1.Remove(employee_1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
