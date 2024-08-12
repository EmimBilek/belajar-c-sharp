using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialTradingPlatformApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Method Name : Main, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            StockMarketTechnicalAnalysisData stockMarket = new StockMarketTechnicalAnalysisData("TOYOTA", new DateTime(2020, 2, 21), new DateTime(2020, 2, 25));

            //DateTime dtmBefore = DateTime.Now;

            Stopwatch watch = new Stopwatch();

            watch.Start();

            // menjalankan method secara sinkron
            //decimal[] data1 = stockMarket.GetOpeningPrice();
            //decimal[] data2 = stockMarket.GetClosingPrice();
            //decimal[] data3 = stockMarket.GetPriceHighs();
            //decimal[] data4 = stockMarket.GetPriceLows();
            //decimal[] data5 = stockMarket.CalculateStockastics();
            //decimal[] data6 = stockMarket.CalculateFastMovingAverage();
            //decimal[] data7 = stockMarket.CalculateSlowMovingAverage();
            //decimal[] data8 = stockMarket.CalculateUpperBoundBollingerBand();
            //decimal[] data9 = stockMarket.CalculateLowerBoundBollingerBand();

            // menjalankan method secara asinkron
            List<Task<decimal[]>> listTask = new List<Task<decimal[]>>();

            Task<decimal[]> calculateStockastics = Task.Run(() => stockMarket.CalculateStockastics());
            Task<decimal[]> calculateFastMovingAverage = Task.Run(() => stockMarket.CalculateFastMovingAverage());
            Task<decimal[]> calculateSlowMovingAverage = Task.Run(() => stockMarket.CalculateSlowMovingAverage());
            Task<decimal[]> calculateUpperBoundBollingerBand = Task.Run(() => stockMarket.CalculateUpperBoundBollingerBand());
            Task<decimal[]> calculateLowerBoundBollingerBand = Task.Run(() => stockMarket.CalculateLowerBoundBollingerBand());
            Task<decimal[]> getOpeningPriceTask = Task.Run(() => stockMarket.GetOpeningPrice());
            Task<decimal[]> getClosingPriceTask = Task.Run(() => stockMarket.GetClosingPrice());
            Task<decimal[]> getPriceHighsTask = Task.Run(() => stockMarket.GetPriceHighs());
            Task<decimal[]> getPriceLowsTask = Task.Run(() => stockMarket.GetPriceLows());

            listTask.Add(getOpeningPriceTask);
            listTask.Add(getClosingPriceTask);
            listTask.Add(getPriceHighsTask);
            listTask.Add(getPriceLowsTask);
            listTask.Add(calculateStockastics);
            listTask.Add(calculateFastMovingAverage);
            listTask.Add(calculateSlowMovingAverage);
            listTask.Add(calculateUpperBoundBollingerBand);
            listTask.Add(calculateLowerBoundBollingerBand);

            Task.WhenAll(listTask);

            decimal[] data1 = listTask[0].Result;
            decimal[] data2 = listTask[1].Result;
            decimal[] data3 = listTask[2].Result;
            decimal[] data4 = listTask[3].Result;
            decimal[] data5 = listTask[4].Result;
            decimal[] data6 = listTask[5].Result;
            decimal[] data7 = listTask[6].Result;
            decimal[] data8 = listTask[7].Result;
            decimal[] data9 = listTask[8].Result;

            //DateTime dtmAfter = DateTime.Now;
            watch.Stop();

            //TimeSpan timeSpan = dtmAfter.Subtract(dtmBefore);

            Console.WriteLine($"Total time for operations to complete took {watch.ElapsedMilliseconds} milisecond(s)");

            DisplayData(data1, data2, data3, data4, data5, data6, data7, data8, data9);

            Console.ReadKey();
        }

        private static void DisplayData(decimal[] data1, decimal[] data2, decimal[] data3, decimal[] data4, decimal[] data5, decimal[] data6, decimal[] data7, decimal[] data8, decimal[] data9)
        {
            // code goes here to display the data
            Console.WriteLine("Data is displayed on chart");
        }
    }

    public class StockMarketTechnicalAnalysisData
    {
        public StockMarketTechnicalAnalysisData(string stockSymbol, DateTime startDate, DateTime endDate)
        {
            // Code to get data from remote server
        }

        public decimal[] GetOpeningPrice()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(GetOpeningPrice)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }

        public decimal[] GetClosingPrice()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(GetClosingPrice)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] GetPriceHighs()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(GetPriceHighs)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] GetPriceLows()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(GetPriceLows)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] CalculateStockastics()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(CalculateStockastics)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(10000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] CalculateFastMovingAverage()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(CalculateFastMovingAverage)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(6000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] CalculateSlowMovingAverage()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(CalculateSlowMovingAverage)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(7000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] CalculateUpperBoundBollingerBand()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(CalculateUpperBoundBollingerBand)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(5000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
        public decimal[] CalculateLowerBoundBollingerBand()
        {
            decimal[] data;

            Console.WriteLine($"Method Name : {nameof(CalculateLowerBoundBollingerBand)}, Thread Id : {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(5000);

            data = new decimal[] { }; // in the real program, the 'data' variable would contain decimal data

            return data;
        }
    }
}
