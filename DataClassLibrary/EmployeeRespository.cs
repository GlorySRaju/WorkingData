using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataClassLibrary
{
    public class EmployeeRespository
    {
        private readonly SqlConnection sqlConnection;
        public EmployeeRespository()
        {
            var connectionString = "data source=(localdb)\\mssqllocaldb; database=Praticedb";
            sqlConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEE", sqlConnection);

                var sqlDataRead= sqlCommand.ExecuteReader();

                var employeeList = new List<Employee>();

                while(sqlDataRead.Read())
                {
                    employeeList.Add(new Employee {
                        Id = (int)sqlDataRead["id"],
                        Name =(string)sqlDataRead["name"],
                        Age=(int)sqlDataRead["age"]
                            });

                }

                return employeeList;

            }
            catch
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public Employee GetEmployee(int emp_id)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEE WHERE id=@id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("id",emp_id);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var employeeList = new List<Employee>();

                while (sqlDataRead.Read())
                {
                    employeeList.Add(new Employee
                    {
                        Id = (int)sqlDataRead["id"],
                        Name = (string)sqlDataRead["name"],
                        Age = (int)sqlDataRead["age"]
                    });

                }


                return employeeList.FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public bool InsertEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("INSERT INTO EMPLOYEE VALUES(@name,@age)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("age", employee.Age);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch
            {
                
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("UPDATE EMPLOYEE SET name=@name,age=@age WHERE id=@id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);

                sqlCommand.Parameters.AddWithValue("age", employee.Age);

                sqlCommand.Parameters.AddWithValue("id", employee.Id);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int emp_id)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("DELETE FROM EMPLOYEE WHERE id=@id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", emp_id);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
