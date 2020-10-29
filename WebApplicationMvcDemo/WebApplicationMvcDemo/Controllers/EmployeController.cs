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
        /// This controller action method will only respond to get request of this url, On click of create button in this view will wil
        /// post data back to db, so for that we will call another method with http post attribute
        /// </summary>
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        /// <summary>
        /// This will respond to post operation
        /// this method need form value to ad the value in db
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            //3. we can also do this without passing any parameter -final
            BusinessLayer.Employee emp = new BusinessLayer.Employee();  // all properties of emp are null
            TryUpdateModel(emp);                  // get binded to form values entered

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
                ebl.AddEmployee(emp);
                return RedirectToAction("GetEmployees");
            }
            else
            {
                return View();
            }

            //end 3

            //2: using update model concept, also doing validation check for values  - Create(BusinessLayer.Employee emp)
            //if (ModelState.IsValid)
            //{
            //    EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            //    ebl.AddEmployee(emp);
            //    return RedirectToAction("GetEmployees");
            //}
            //else
            //{
            //    return View();  // return create view  
            //}
            // end 2

            // 1.Not good idea Redundat code -  Create(FormCollection formCollection)
            //BusinessLayer.Employee emp = new BusinessLayer.Employee();

            //emp.Id = Convert.ToInt32(formCollection["Id"]);
            //emp.Name = formCollection["Name"];
            //emp.Gender = formCollection["Gender"];
            //emp.City = formCollection["City"];
            //emp.DateOfBirth = DateTime.ParseExact(formCollection["DateOfBirth"], "dd/MM/yyyy", null);

            //EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            //ebl.AddEmployee(emp);
            // return RedirectToAction("GetEmployees");
            //end 1

        }

    }
}