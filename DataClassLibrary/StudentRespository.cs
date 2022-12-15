using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataClassLibrary
{

    public class StudentRespository
    {
        private readonly SqlConnection sqlConnection;

        public StudentRespository()
        {
            var connectionString = "data source = (localdb)\\mssqllocaldb; database = Praticedb";

            sqlConnection = new SqlConnection(connectionString);
        }
        public IEnumerable<Student> GetStudents()
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("select * from STUDENT_TABLE", sqlConnection);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var studentList = new List<Student>();



                while (sqlDataRead.Read())
                {
                    studentList.Add(new Student
                    {
                        Id = (int)sqlDataRead["id"],
                        Name = (string)sqlDataRead["name"],
                        Dept = (string)sqlDataRead["dep"]
                    });
                }
                return studentList;
            }

            catch (Exception expection)
            {
                throw;

            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public Student GetStudent(int stu_id)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("select * from STUDENT_TABLE where id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", stu_id);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var studentList = new List<Student>();

                while (sqlDataRead.Read())
                {
                    studentList.Add(new Student
                    {
                        Id = (int)sqlDataRead["id"],
                        Name = (string)sqlDataRead["name"],
                        Dept = (string)sqlDataRead["dep"]
                    });
                }
                return studentList.FirstOrDefault();
            }

            catch (Exception expection)
            {
                throw;

            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public bool Insert(Student student)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("INSERT INTO STUDENT_TABLE VALUES(@name,@age)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", student.Name);
                sqlCommand.Parameters.AddWithValue("age", student.Dept);

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
        public bool Update(Student student)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("UPDATE STUDENT_TABLE SET name=@name WHERE id=@id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", student.Id);

                sqlCommand.Parameters.AddWithValue("name", student.Name);

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
        public bool Delete(int stu_id)
        {
            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand("DELETE FROM STUDENT_TABLE WHERE id=@id;", sqlConnection);

                sqlCommand.Parameters.AddWithValue("id",stu_id);

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

