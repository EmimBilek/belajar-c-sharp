using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarGeneric2_Constraint_Non_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] arrint = { 10, 23, 5, 7, 82, 56 };
            string[] arrstr = { "Amogus", "Cukurukuk", "Brainrot", "Ambatukam" };
            Employee[] arremp = new Employee[] {
                new Employee { id = 1, name = "sugomadik" },
                new Employee { id = 4, name = "amogus" },
                new Employee { id = 3, name = "waluyo" },
                new Employee { id = 8, name = "siti badriah" } };

            SortArray sort = new SortArray();

            sort.BubbleSort(arremp);

            //PrintArray(arrstr);

            foreach (var a in arremp)
            {
                Console.WriteLine(a);
            }

            //PrintArray(arrint);
            //BubbleSort(ref arrint);
            //Console.WriteLine("--Sorted--");
            //PrintArray(arrint);

            Console.ReadKey();
        }
        private static void PrintArray(object[] arr)
        {
            Console.Write("Value of an array : ");
            foreach (object a in arr)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
        }
    }

    public class Employee : IComparable
    {
        public int id { get; set; }
        public string name { get; set; }

        public int CompareTo(object obj)
        {
            return this.name.CompareTo(((Employee)obj).name);
        }

        public override string ToString()
        {
            return $"{id}. {name}";
        }
    }

    public class SortArray
    {
        public void BubbleSort(object[] arr)
        {

            for (int len = arr.Length; len >= 1; len--)
                for (int i = 0; i < len - 1; i++)
                {
                    if (((IComparable)arr[i]).CompareTo(arr[i + 1]) > 0)
                    {
                        SwapArray(arr, i);
                    }
                }
        }

        private void SwapArray(object[] arr, int index)
        {
            object temp = arr[index];
            arr[index] = arr[index + 1];
            arr[index + 1] = temp;
        }
    }
}
