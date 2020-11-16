using MvcDemoUsingEntityFW.Models;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Mvc;

namespace MvcDemoUsingEntityFW.Controllers
{
    public class HtmlHelpersController : Controller
    {
        // GET: HtmlHelpers
        public ActionResult Index()
        {
            MvcSampleEntities_dropdownlisthh2 context = new MvcSampleEntities_dropdownlisthh2();

            List<SelectListItem> dropdownitems = new List<SelectListItem>();
            foreach(Department dept in context.Departments)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = dept.Name,
                    Value = dept.Id.ToString(),
                    Selected = dept.IsSelected.HasValue ? dept.IsSelected.Value : false
                };
                dropdownitems.Add(item);
            }

            ViewBag.Departments = dropdownitems;
            return View();
        }

        public ActionResult ForAndNormalControl()
        {
            Company company = new Company("Megha company");

            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;
            return View();
        }

        public ActionResult RadioButtonExample()
        {
            Company company = new Company("Megha Compay");
            return View();
        }
    }
}