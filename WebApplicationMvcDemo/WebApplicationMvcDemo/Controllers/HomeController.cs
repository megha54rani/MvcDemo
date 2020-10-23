using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id,string name)
        {
            //return "Id="+id + " Name="+ Request.QueryString["name"];
            ViewBag.Countries =  new List<string>()
            {
                "India",
                "US",
                "Canada",
                "Uk"
            };

            return View();
        }
    }
}