using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    class SecurityNotify : Observer
    {

        public override void OnCompleted()
        {
            string heading = $"Security Daily Visitor Report";
            Console.WriteLine();
            Console.WriteLine(heading);
            Console.WriteLine(new string('-', heading.Length));
            Console.WriteLine();

            foreach (var visitor in _externalVisitors)
            {
                Console.WriteLine($"{visitor.id,-6}{visitor.firstName,-15}{visitor.lastName,-15}{(visitor.entryDateTime.ToString("dd MMMM yyyy:HH.mm.ss")),-25}{(visitor.exitDateTime.ToString("dd MMMM yyyy:HH.mm.ss")),-25}");
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

            var externalVisitorListItem = _externalVisitors.FirstOrDefault(e => e.id == externalVisitor.id);
            OutputFormatter.ChangeTheme(OutputFormatter.ThemeFormat.Security);
            if (externalVisitorListItem == null)
            {
                _externalVisitors.Add(externalVisitor);
                Console.WriteLine($"Security Notification: Visitor has arrived. Visitor ID {externalVisitor.id}, {externalVisitor.firstName} {externalVisitor.lastName}, Visit time : {(externalVisitor.entryDateTime.ToString("dd MMMM yyyy:HH.mm.ss"))}");
            }
            else
            {
                if (externalVisitorListItem.inBuilding == false)
                {
                    externalVisitorListItem.inBuilding = false;
                    externalVisitorListItem.entryDateTime = externalVisitor.exitDateTime;

                    Console.WriteLine($"Security Notification: Visitor has exited the building. Visitor ID {externalVisitor.id}, {externalVisitor.firstName} {externalVisitor.lastName}, Exit time : {(externalVisitor.entryDateTime.ToString("dd MMMM yyyy:HH.mm.ss"))}");
                }
            }
            OutputFormatter.ChangeTheme(OutputFormatter.ThemeFormat.Normal);
        }
    }
}
