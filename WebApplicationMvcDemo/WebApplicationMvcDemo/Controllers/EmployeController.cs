using BusinessLayer;
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
            Models.Employee employee = empContext.Employees.Single(emp => emp.Id == id);
            return View(employee);
        }

        /// <summary>
        /// List of all employees
        /// </summary>
        public ActionResult EmployeeList(int deptId)
        {
            EmployeeContext empContext = new EmployeeContext();
           List<Models.Employee> employees = empContext.Employees.Where(emp => emp.DepartmentId == deptId).ToList();
            return View(employees);
        }

        // using business object

        /// <summary>
        /// using business object class  //Get
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEmployees()
        {
            EmployeeBusinessLayer emp = new EmployeeBusinessLayer();
            List<BusinessLayer.Employee> employees = emp.Employees.ToList();
            return View(employees);
        }
/// <summary>
/// This controller action method will only respond to get request of this url
/// </summary>
/// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}