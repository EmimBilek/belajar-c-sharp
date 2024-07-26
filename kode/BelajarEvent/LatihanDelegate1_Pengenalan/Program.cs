using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanEvent1_Pengenalan
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter count = new Counter(new Random().Next(10));
            count.TresholdReached += c_ThresholdReached;
            Console.WriteLine("Press \'a\' for add one");

            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                count.Add(1);  
            }
        }

        static void c_ThresholdReached(object sender, TresholdReachedEventArgs e)
        {
            Console.WriteLine($"Threshold has been reached at {e.threshold} - {e.time}");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }

    public class Counter
    {
        private int treshold;
        private int total;

        public Counter(int tres)
        {
            treshold = tres;
        }

        public void Add(int a)
        {
            total += a;
            if (total >= treshold)
            {
                TresholdReachedEventArgs tresh = new TresholdReachedEventArgs();
                tresh.threshold = treshold;
                tresh.time = DateTime.Now;
                OnTresholdReached(tresh);
                //Console.WriteLine($"Threshold has been reached at {tresh.threshold} - {tresh.time}");
                //Console.ReadKey();
                //Environment.Exit(0);
            }
        }

        protected void OnTresholdReached(TresholdReachedEventArgs tres)
        {
            EventHandler<TresholdReachedEventArgs> even = TresholdReached;
            if (even != null)
            {
                even(this, tres);
            }
        }

        public event EventHandler<TresholdReachedEventArgs> TresholdReached;
    }

    public class TresholdReachedEventArgs : EventArgs
    {
        public int threshold { get; set; }
        public DateTime time { get; set; }
    }
}
