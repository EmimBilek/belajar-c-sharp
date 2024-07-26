using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    public interface IEmployee
    {
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string jobTitle { get; set; }
    }
    public class Employee : IEmployee
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
    }
    public class EmployeeNotify : Observer
    {
        IEmployee _employee = null;

        public EmployeeNotify(IEmployee employee)
        {
            _employee = employee;
        }

        public override void OnCompleted()
        {
            string heading = $"{_employee.firstName} {_employee.lastName}\'s Daily Visitor Report";
            Console.WriteLine();
            Console.WriteLine(heading);
            Console.WriteLine(new string('-', heading.Length));
            Console.WriteLine();

            foreach (var visitor in _externalVisitors)
            {
                Console.WriteLine($"{visitor.id, -6}{visitor.firstName, -15}{visitor.lastName, -15}{(visitor.entryDateTime.ToString("dd MMMM yyyy:HH.mm.ss")), -25}{(visitor.exitDateTime.ToString("dd MMMM yyyy:HH.mm.ss")),-25}");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(ExternalVisitor value)
        {
            var externalVisitor = value;

            if (externalVisitor.employeeContactId == _employee.id)
            {
                var externalVisitorListItem = _externalVisitors.FirstOrDefault(e => e.employeeContactId == _employee.id);
                OutputFormatter.ChangeTheme(OutputFormatter.ThemeFormat.Employee);
                if (externalVisitorListItem == null)
                {
                    _externalVisitors.Add(externalVisitor);
                    Console.WriteLine($"{_employee.firstName} {_employee.lastName}, your Visitor has arrived. Visitor ID {externalVisitor.id}, {externalVisitor.firstName} {externalVisitor.lastName}, Visit time : {(externalVisitor.entryDateTime.ToString("dd MMMM yyyy:HH.mm.ss"))}");
                }
                else
                {
                    if (externalVisitor.inBuilding == false)
                    {
                        externalVisitorListItem.inBuilding = false;
                        externalVisitorListItem.entryDateTime = externalVisitor.exitDateTime; 
                    }
                }
                OutputFormatter.ChangeTheme(OutputFormatter.ThemeFormat.Normal);
            }
        }
    }
}
