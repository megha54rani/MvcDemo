using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    /// <summary>
    /// Contain all business logic and validation for employee
    /// Business layer will call data access layer
    /// Here just accessing data from db, and including code here itself
    /// </summary>
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                // string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                string connectionString = "server=KOR1085459\\SQLEXPRESS; database=MvcSample; integrated Security=SSPI";

                List<Employee> employees = new List<Employee>();

                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spGetAllEmployees", con);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(rdr["Id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }
    }
}
