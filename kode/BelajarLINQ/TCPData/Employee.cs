using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }

        public override string ToString()
        {
            Department department = Data.GetDepartmentById(DepartmentId);
            return $"({Id}) {FirstName} {LastName} {(IsManager ? "is Manager" : "is not Manager")} at Department {department.LongName} ({department.ShortName}) with total salary : {AnnualSalary}";
        }
    }
}
