using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SecuritySurveillanceHub securitySurveillanceHub = new SecuritySurveillanceHub();
            EmployeeNotify employeeNotify = new EmployeeNotify(new Employee
            {
                id = 1,
                firstName = "Momog",
                lastName = "Gus",
                jobTitle = "Manager"
            });

            EmployeeNotify employeeNotify2 = new EmployeeNotify(new Employee
            {
                id = 2,
                firstName = "Mogus",
                lastName = "Sus",
                jobTitle = "CEO"
            });

            SecurityNotify securityNotify = new SecurityNotify();

            employeeNotify.Subscribe(securitySurveillanceHub);
            employeeNotify2.Subscribe(securitySurveillanceHub);
            securityNotify.Subscribe(securitySurveillanceHub);

            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(1, "Skibidi", "Toilet", "Taxing", "Skibidi Company", DateTime.Parse("14-07-2024 11:00"), 1);
            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(2, "Lux", "Maxxing", "Mewing", "Sigma Company", DateTime.Parse("14-07-2024 12:00"), 2);

            employeeNotify2.Unsubscribe();
            
            securitySurveillanceHub.ConfirmExternalVisitorExitBuilding(1, DateTime.Parse("14-07-2024 13:00"));
            securitySurveillanceHub.ConfirmExternalVisitorExitBuilding(2, DateTime.Parse("14-07-2024 15:00"));

            securitySurveillanceHub.BuildingEntryCutOffTimeReached();

            Console.ReadKey();
        }
    }
}
