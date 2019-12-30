using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BL_Employees
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

                List<Employee> employees = new List<Employee>();

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetAllEmployees", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employee employee = new Employee();

                        employee.CNIC = Convert.ToDouble(rdr["CNIC"]);
                        employee.FirstName = rdr["FirstName"].ToString();
                        employee.LastName = rdr["LastName"].ToString();
                        employee.FatherName = rdr["FatherName"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.EmployeePassword = rdr["EmployeePassword"].ToString();
                        employee.Mobile = Convert.ToDouble(rdr["Mobile"]);
                        employee.Landline = Convert.ToDouble(rdr["Landline"]);
                        employee.Salary = Convert.ToDouble(rdr["Salary"]);
                        employee.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                        employee.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                        employee.PresentAddress = rdr["PresentAddress"].ToString();
                        employee.PostTitle = rdr["PostTitle"].ToString();
                        employee.StationName = rdr["StationName"].ToString();
                        employee.AccountType = rdr["AccountType"].ToString();

                        employees.Add(employee);
                    }

                }
                return employees;
            }
        }

        public void InsertEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spInsert_vwCompleteEmployeesDetail", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CNIC", employee.CNIC);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@EmployeePassword", employee.EmployeePassword);
                cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
                cmd.Parameters.AddWithValue("@Landline", employee.Landline);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@PresentAddress", employee.PresentAddress);
                cmd.Parameters.AddWithValue("@PostTitle", employee.PostTitle);
                cmd.Parameters.AddWithValue("@StationName", employee.StationName);
                cmd.Parameters.AddWithValue("@AccountType", employee.PostTitle);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteEmployee(double _CNIC)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComplainContext"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDelete_vwCompleteEmployeesDetail", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CNIC", _CNIC);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }


        }

    }
}
