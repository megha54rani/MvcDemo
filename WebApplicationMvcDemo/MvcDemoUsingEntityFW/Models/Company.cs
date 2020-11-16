using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemoUsingEntityFW.Models
{
    public class Company
    {
        private string _name;  // this name will be displayed in tb control
        public Company(string name)
        {
            this._name = name;
        }

        public List<Department> Departments
        {
            get
            {
                MvcSampleEntities_dropdownlisthh2 context = new MvcSampleEntities_dropdownlisthh2();
                return context.Departments.ToList();
            }
        }

        public string CompanyName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string SelectedDepartment {  get;set; }
    }
}