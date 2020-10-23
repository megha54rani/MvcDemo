using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMvcDemo.Models;

namespace WebApplicationMvcDemo.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Details(int id)
        {
            EmployeeContext empContext = new EmployeeContext();
            Employee employee = empContext.Employees.Single(emp => emp.Id == id);
            return View(employee);
        }

        public ActionResult EmployeeList()
        {
            EmployeeContext empContext = new EmployeeContext();
           List<Employee> employees = empContext.Employees.ToList();
            return View(employees);
        }
    }
}