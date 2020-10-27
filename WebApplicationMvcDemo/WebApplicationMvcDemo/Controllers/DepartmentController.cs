using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplicationMvcDemo.Models;

namespace WebApplicationMvcDemo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Departments()
        {
            EmployeeContext emp = new EmployeeContext();
            List<Department> departments = emp.Departments.ToList();
            return View(departments);
        }
    }
}