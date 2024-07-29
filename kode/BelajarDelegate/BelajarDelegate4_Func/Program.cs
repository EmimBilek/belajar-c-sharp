using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarDelegate4_FuncActionPredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //MathClass mth = new MathClass();

            //Func<T1, T2, T3... TResult> bisa menggunakan hingga 16 generic, generic terakhir merupakan hasil return dari sebuah Func, contoh di bawah menggunakan 3 generic, 2 generic pertama sebagai parameter, 1 generic terakhir sebagai tipe return

            //Func<int, int, int> calc = mth.Sum; //method biasa

            //Func<int, int, int> calc = delegate (int a, int b) { return a + b; }; //method anonymous

            //Func<int, int, int> calc = (a, b) => (a + b); //lambda expression (versi pendeknya anonymous method)

            //int total = calc(1, 4);

            //Console.WriteLine($"Total sum : {total}");

            Func<decimal, decimal, decimal> gajiDenganBonus = (gajiSekarang, bonusDalamPersen) => gajiSekarang + (gajiSekarang * (bonusDalamPersen / 100));

            Action<int, string, decimal, bool> displayEmployee = delegate (int id, string name, decimal salary, bool isManager) { Console.WriteLine($"ID : {id}{Environment.NewLine}Name : {name}{Environment.NewLine}Salary : {salary}{Environment.NewLine}Position : {(isManager ? "Manager" : "Not Manager")}"); };

            //decimal totalGaji = gajiDenganBonus(58000, 50);

            //Console.WriteLine($"Gaji diterima bulan ini : {totalGaji}");

            string mog = "KaCAwaCaK";
            Console.WriteLine($"Is it same as the other string? : {mog.CompareCaseSensitive("KaCAwaCaK")} ");

            //Console.ReadLine();

            //List<Employee> listemp = new List<Employee>();
            //listemp.Add(new Employee { id = 1, name = "Sigmamogus", annualSalary = gajiDenganBonus(130000, 5), isManager = false });
            //listemp.Add(new Employee { id = 2, name = "Skibiditoilet", annualSalary = gajiDenganBonus(54000, 55), isManager = true });
            //listemp.Add(new Employee { id = 3, name = "Messikimoci", annualSalary = gajiDenganBonus(24500, 40), isManager = true });
            //listemp.Add(new Employee { id = 4, name = "Komengakak", annualSalary = gajiDenganBonus(89000, 10), isManager = false });

            //List<Employee> employeeFiltered = FilterEmployees(listemp, e => e.annualSalary > 50000); //menggunakan method
            //List<Employee> employeeFiltered = listemp.FilterEmployees(e => !e.isManager); //menggunakan extension
            //List<Employee> employeeFiltered = listemp.Where(e => !e.isManager).ToList(); //menggunakan linq
            //displayEmployees(listemp);

            //foreach (Employee emp in listemp)
            //{
            //    displayEmployee(emp.id, emp.name, emp.annualSalary, emp.isManager);
            //    Console.WriteLine();
            //}

            Console.ReadKey();
        }

        static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeeFiltered = new List<Employee>();

            foreach(Employee emp in employees)
            {
                if (predicate(emp))
                {
                    employeeFiltered.Add(emp);
                }
            }
            return employeeFiltered;
        }

        static void displayEmployees(List<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID : {emp.id} {Environment.NewLine}Nama : {emp.name}{Environment.NewLine}Annual Salary : {emp.annualSalary}{Environment.NewLine}Is Manager : {emp.isManager}");
                Console.WriteLine();
            }
        }
    }

    public static class Extensions // kelas extension yang dibikin sendiri 
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeeFiltered = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (predicate(emp))
                {
                    employeeFiltered.Add(emp);
                }
            }
            return employeeFiltered;
        }

        ///
        /// <summary>
        ///     Check string if it same as reversed-form. Return true if it is same, otherwise false. Case from each letter will be ignored
        /// </summary>
        /// 
        /// <param name="text">
        ///   text:
        ///     A string that will be checked.
        /// </param>
        /// 
        /// <returns>
        ///     A boolean.
        ///</returns>
        /// 
        public static bool IsPalindrom(this string text)
        {
            string textReversed = new string(text.Reverse().ToArray());
            if (text.ToLower() == textReversed.ToLower())
            {
                return true;
            }
            return false;
        }

        public static bool CompareCaseSensitive(this string text, string textToCompare)
        {
            if (text == textToCompare)
            {
                return true;
            }
            return false;
        }
    }

    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal annualSalary { get; set; }
        public bool isManager { set; get; }
    }

    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
