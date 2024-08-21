using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarLINQ2_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GenerateEmployees();
            List<Department> departmentList = Data.GenerateDepartments(employeeList);

            //List<Employee> employeeList2 = Data.GenerateEmployees();

            //var results = employeeList.Select(e => new
            //{
            //    FullName = e.FirstName + " " + e.LastName,
            //    AnnualSalary = e.AnnualSalary
            //}).Where(e => e.AnnualSalary < 50000m);

            //var results = from emp in employeeList
            //              where emp.AnnualSalary < 50000
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary
            //              };

            //foreach (var item in results)
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");

            //// Contoh join menggunakan sintaks method
            //var results = departmentList.Join(employeeList,
            //        department => department.Id,
            //        employee => employee.DepartmentId,
            //        (department, employee) => new
            //        {
            //            FullName = employee.FirstName + " " + employee.LastName,
            //            AnnualSalary = employee.AnnualSalary,
            //            DepartmentName = department.LongName
            //        }
            //    ).OrderBy(o => o.DepartmentName).ThenBy(o => o.FullName);

            //foreach (var item in results)
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");

            //// Contoh join menggunakan sintaks query
            //var results = from departments in departmentList
            //              join employees in employeeList on
            //              departments.Id equals employees.DepartmentId
            //              where employees.AnnualSalary > 50000
            //              orderby employees.FirstName + " " + employees.LastName, departments.LongName descending
            //              select new
            //              {
            //                  FullName = employees.FirstName + " " + employees.LastName,
            //                  AnnualSalary = employees.AnnualSalary,
            //                  DepartmentName = departments.LongName
            //              };

            //foreach (var item in results)
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");

            // Contoh groupjoin menggunakan sintaks method
            //var results = departmentList.GroupJoin(employeeList,
            //        dept => dept.Id,
            //        emp => emp.DepartmentId,
            //        (depart, employeesGroup) => new
            //        {
            //            Employees = employeesGroup,
            //            DepartmentName = depart.LongName
            //        });

            //foreach (var item in results)
            //{
            //    Console.WriteLine($" Department Name : {item.DepartmentName}");
            //    foreach (var emp in item.Employees)
            //    {
            //        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
            //    }
            //}

            // Contoh groupjoin menggunakan sintaks query
            //var results = from dep in departmentList
            //              join emp in employeeList
            //              on dep.Id equals emp.DepartmentId
            //              into employeesGroup
            //              select new
            //              {
            //                  Employees = employeesGroup,
            //                  DepartmentName = dep.LongName
            //              };

            //foreach (var item in results)
            //{
            //    Console.WriteLine($" Department Name : {item.DepartmentName}");
            //    foreach (var emp in item.Employees)
            //    {
            //        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
            //    }
            //}

            //var checkEmp = new Employee { Id = 1, FirstName = "Momog", LastName = "Gus", AnnualSalary = 45000.2m, IsManager = true, DepartmentId = 2 };

            //var results = employeeList.DefaultIfEmpty();

            //Console.WriteLine(results);

            //var list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var list2 = new List<int> { 1, 2, 3, 4, 5, 6 };

            //bool result = employeeList.SequenceEqual(employeeList2);

            //Console.WriteLine(result);

            //if (results != null)
            //    Console.WriteLine($"{results.Id} {results.FirstName}");
            //else
            //    Console.WriteLine($"Data not found");

            //var results2 = from emp in employeeList
            //              where emp.IsManager
            //              select emp;

            //foreach (var result2 in results2)
            //    Console.WriteLine($"{result2.Id} : {result2.FirstName} {result2.LastName} {(result2.IsManager ? "is Manager" : "is not Manager")}");

            //ArrayList arr = new ArrayList();

            //arr.Add(2000);
            //arr.Add("Kucing");
            //arr.Add(new Employee { Id = 5, AnnualSalary = 3000, DepartmentId = 2, FirstName = "iteng", LastName = "hitam", IsManager = false });
            //arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });
            //arr.Add(800);
            //arr.Add("ase omagat asi deway yu sain");
            //arr.Add(new Employee { Id = 7, AnnualSalary = 9000, DepartmentId = 2, FirstName = "jarwo", LastName = "dontol", IsManager = true });
            //arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });
            //arr.Add(7800);
            //arr.Add("selaluuu, selagi jang ganggu");
            //arr.Add(new Employee { Id = 6, AnnualSalary = 8230, DepartmentId = 2, FirstName = "harung", LastName = "hideung", IsManager = true });
            //arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });

            //var results = from ar in arr.OfType<string>()
            //              select ar;

            //foreach(var result in results)
            //{
            //    Console.WriteLine(result);
            //}

            //List<Employee> employeet = Enumerable.Empty<Employee>().ToList();

            //Console.WriteLine((employeet.Count <= 0 ? "Kosong" : "Ada isinya"));

            //employeet.Add(new Employee { Id = 20, FirstName = "miaw", LastName = "miyau" });

            //Dictionary<int, Employee> deretEmployee = Enumerable.Repeat(new Employee { FirstName = "Kuma", LastName = "Lala" }, 10).Select((e, index) => new Employee { Id = index + 1, FirstName = e.FirstName, LastName = e.LastName }).ToDictionary<Employee, int>(e => e.Id);
            //foreach (var key in deretEmployee.Keys)
            //    Console.WriteLine($"ID : {key}, {deretEmployee[key].FirstName} {deretEmployee[key].LastName}");

            //var result = from emp in employeeList
            //             let Inisial = emp.FirstName.Substring(0, 1).ToUpper() + emp.LastName.Substring(0, 1).ToUpper()
            //             let SalaryWithBonus = emp.IsManager ? (emp.AnnualSalary + (emp.AnnualSalary * 0.1m)) : (emp.AnnualSalary + (emp.AnnualSalary * 0.05m))
            //             select new
            //             {
            //                 Id = emp.Id,
            //                 FirstName = emp.FirstName,
            //                 LastName = emp.LastName,
            //                 Initial = Inisial,
            //                 SalaryWithBonus = SalaryWithBonus
            //             };

            //foreach (var employi in result)
            //    Console.WriteLine($"{employi.Id} {employi.Initial}. {employi.FirstName} {employi.LastName}, Salary (With bonus) : {employi.SalaryWithBonus}");

            //List<int> listInt = new List<int> { 1, 2, 2, 5, 4, 3, 5, 3, 6, 7, 9, 8, 6, 7, 8, 0, 7, 5 };
            //var distinctedInt = listInt.Distinct().OrderBy(e => e);
            //List<int> listInt = new List<int> { 1, 2, 2, 5, 4, 3, 5, 3, 6, 7, 9, 8, 6, 7, 8, 0, 7, 5 };
            //List<int> listInt2 = new List<int> { 1, 2, 2, 5, 4, 3, 5, 3, 6, 7, 9, 8, 6, 7, 10, 19, 13, 12 };

            //var unionInt = listInt.Union(listInt2).OrderBy(e => e);

            //foreach (int t in unionInt)
            //Console.WriteLine(t);

            //var results = departmentList.SelectMany(d => d.Employees).OrderBy(d=>d.DepartmentId);

            //foreach (var result in results)
            //    Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName} {result.DepartmentId}");

            var results1 = departmentList.Select(d => d.Employees);

            foreach (var result1 in results1)
                foreach(var result in result1)
                    Console.WriteLine($"{result.Id} {result.FirstName} {result.LastName} {result.DepartmentId}");

            Console.ReadKey();
        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return (x.FirstName.ToLower() == y.FirstName.ToLower()) && (x.LastName.ToLower() == y.LastName.ToLower());
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Accessing employee : {emp.FirstName} {emp.LastName}");
                if (emp.AnnualSalary >= 50000m)
                    yield return emp;
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || this.GetType() != obj.GetType())
        //        return false;

        //    Employee emp = (Employee)obj;

        //    return (this.FirstName.ToLower() == emp.FirstName.ToLower()) && (this.LastName.ToLower() == emp.LastName.ToLower());
        //}

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
    public static class Data
    {
        public static List<Employee> GenerateEmployees()
        {
            List<Employee> ls = new List<Employee>();

            ls.Add(new Employee { Id = 1, FirstName = "Momog", LastName = "Gus", AnnualSalary = 45000.2m, IsManager = true, DepartmentId = 2 });
            ls.Add(new Employee { Id = 2, FirstName = "Skibidi", LastName = "Toilet", AnnualSalary = 87400.1m, IsManager = false, DepartmentId = 1 });
            ls.Add(new Employee { Id = 3, FirstName = "Sikma", LastName = "Mel", AnnualSalary = 82900.4m, IsManager = true, DepartmentId = 3 });
            ls.Add(new Employee { Id = 4, FirstName = "GedaGedi", LastName = "GedaGedaO", AnnualSalary = 37000.9m, IsManager = false, DepartmentId = 2 });

            return ls;
        }

        public static List<Department> GenerateDepartments(IEnumerable<Employee> Emplyes)
        {
            List<Department> departments = new List<Department>();

            departments.Add(new Department { Id = 1, ShortName = "RZ", LongName = "Rizzing", Employees = Emplyes.Where(e => e.DepartmentId == 1) });
            departments.Add(new Department { Id = 2, ShortName = "EG", LongName = "Edging", Employees = Emplyes.Where(e => e.DepartmentId == 2) });
            departments.Add(new Department { Id = 3, ShortName = "YP", LongName = "Yapping", Employees = Emplyes.Where(e => e.DepartmentId == 3) });

            return departments;
        }
    }
}
