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
                        if (!(rdr["Id"] is DBNull))
                        {
                            employee.Id = Convert.ToInt32(rdr["Id"]);
                        }
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        if (!(rdr["DateOfBirth"] is DBNull))
                        {
                            employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }
                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            string connectionString = "server=KOR1085459\\SQLEXPRESS; database=MvcSample; integrated Security=SSPI";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAddEmployee", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                command.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                command.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                command.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                command.Parameters.Add(paramDateOfBirth);

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                command.Parameters.Add(paramId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
