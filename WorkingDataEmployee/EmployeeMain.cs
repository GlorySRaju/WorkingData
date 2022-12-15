using System;
using DataClassLibrary;

namespace WorkingDataEmployee
{
    class EmployeeMain
    {
        static void Main(string[] args)
        {
            var employee = new EmployeeRespository();

            try
            {

               var employees = employee.GetEmployees();

                foreach (var item in employees)
                {
                    Console.WriteLine($"{item.Id}--{item.Name}--{item.Age}");
                }

                Console.WriteLine(employee.GetEmployee(3).Id + employee.GetEmployee(3).Name + employee.GetEmployee(3).Age);

                var employeeInserObject = new Employee()
                {
                    Name = "devi",
                    Age = 28
                };

                if (employee.InsertEmployee(employeeInserObject))
                {
                    Console.WriteLine("INSERTED SUCCESSFULLY");
                }

                if (employee.UpdateEmployee(new Employee(){ Id = 2, Name = "fifa", Age = 26 }))
                {
                    Console.WriteLine("UPDATED SUCCESSFULLY");
                }

                if(employee.DeleteEmployee(1))
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
