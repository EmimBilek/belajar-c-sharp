using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarGeneric1_Pengenalan
{
    class Program
    {
        static void Main(string[] args)
        {
            Salaries salaries = new Salaries();

            //ArrayList salaryList = salaries.GetSalaryList();

            List<float> salaryList = salaries.GetSalaryList();

            //float salary = (float)salaryList[1];

            float salary = salaryList[1];

            Console.WriteLine($"Gaji : {salary}");

            Console.ReadKey();
        }
    }

    class Salaries
    {
        //ArrayList _salaryList = new ArrayList();
        List<float> _salaryList = new List<float>();
        public Salaries()
        {
            _salaryList.Add(6000.03f);
            _salaryList.Add(4230.80f);
            _salaryList.Add(8510.43f);
        }

        //public ArrayList GetSalaryList()
        public List<float> GetSalaryList()
        {
            return _salaryList;
        }
    }
}
