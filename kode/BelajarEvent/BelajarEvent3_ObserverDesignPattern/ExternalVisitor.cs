using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    public class ExternalVisitor
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
        public string companyName { get; set; }
        public DateTime entryDateTime { get; set; }
        public DateTime exitDateTime { get; set; }
        public bool inBuilding { get; set; }
        public int employeeContactId { get; set; }
    }
}
