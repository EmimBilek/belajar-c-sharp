using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GenerateEmployees()
        {
            List<Employee> ls = new List<Employee>();

            ls.Add(new Employee { Id = 1, FirstName = "Momog", LastName = "Gus", AnnualSalary = 45000.2m, IsManager = true, DepartmentId = 2 });
            ls.Add(new Employee { Id = 2, FirstName = "Skibidi", LastName = "Toilet", AnnualSalary = 87400.1m, IsManager = false, DepartmentId = 1 });
            ls.Add(new Employee { Id = 3, FirstName = "Sikma", LastName = "Mel", AnnualSalary = 82900.4m, IsManager = true, DepartmentId = 1 });
            ls.Add(new Employee { Id = 4, FirstName = "GedaGedi", LastName = "GedaGedaO", AnnualSalary = 37000.9m, IsManager = false, DepartmentId = 2 });

            return ls;
        }

        public static List<Department> GenerateDepartments()
        {
            List<Department> departments = new List<Department>();

            departments.Add(new Department { Id = 1, ShortName = "RZ", LongName = "Rizzing" });
            departments.Add(new Department { Id = 2, ShortName = "EG", LongName = "Edging" });
            departments.Add(new Department { Id = 3, ShortName = "YP", LongName = "Yapping" });

            return departments;
        }

        public static Department GetDepartmentById(int id)
        {
            List<Department> departments = GenerateDepartments();

            return departments.Where((department) => department.Id.Equals(id)).First();
        }
    }
}
