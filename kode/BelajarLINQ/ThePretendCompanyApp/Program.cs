using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;
using TCPExtensions;

namespace ThePretendCompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Data.GenerateEmployees();
            List<Department> departments = Data.GenerateDepartments();
            var filteredEmployee = employees.Where((employee) => !employee.IsManager);
            //var selectEmpAndDept = (from emp in employees
            //                       join dep in departments
            //                       on emp.DepartmentId equals dep.Id
            //                       select new
            //                       {
            //                           EmployeeId = emp.Id,
            //                           FirstName = emp.FirstName,
            //                           LastName = emp.LastName,
            //                           DepartmentShortName = dep.ShortName,
            //                           DepartmentLongName = dep.LongName,
            //                           AnnualSalary = emp.AnnualSalary,
            //                           IsManager = emp.IsManager
            //                       });
            //foreach(var employee in selectEmpAndDept)
            //{
            //    Console.WriteLine($"({employee.EmployeeId}) {employee.FirstName} {employee.LastName} {(employee.IsManager ? "is Manager" : "is not Manager")} at Department {employee.DepartmentLongName} ({employee.DepartmentShortName}) with total salary : {employee.AnnualSalary}");
            //}

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadKey();
        }
    }
}
