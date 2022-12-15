using DataClassLibrary;
using System;

namespace WorkingData
{
    class StudentMain
    {

        static void Main(string[] args)
        {

            var student = new StudentRespository();


            try
            {
                var students = student.GetStudents();

                Console.WriteLine(student.GetStudent(4).Id + student.GetStudent(4).Name + student.GetStudent(4).Dept);


                foreach (var item in students)
                {
                    Console.WriteLine($"{item.Id}--{item.Name}--{item.Dept}");
                }


                var studentInsertObj = new Student()
                {
                    Name = "sanu",
                    Dept = "msc",
                };
                if (student.Insert(studentInsertObj))
                {
                    Console.WriteLine("INSERTED SUCCESSFULLY");
                }

                var studentUpdateObj = new Student()
                {
                    Id = 1,
                    Name = "glorys",
                };
                if (student.Update(studentUpdateObj))
                {
                    Console.WriteLine("UPDATED SUCCESSFULLY");
                }

                if (student.Delete(3))
                {
                    Console.WriteLine("DELETED SUCCESSFULLY");
                }

            }
            catch (Exception expection)
            {
                Console.WriteLine(expection.Message);
            }


        }
    }
}
