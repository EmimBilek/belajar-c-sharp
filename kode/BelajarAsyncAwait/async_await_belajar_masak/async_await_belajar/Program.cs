using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using MetodeMasak;

namespace async_await_belajar
{
    class Program
    {
        private static MetodeMasakSarapan metod = new MetodeMasakSarapan();
        static async Task Main(string[] args)
        {
            Console.Write("Tekan \"Enter\" untuk mulai memasak");
            Console.ReadLine();
            var watch = Stopwatch.StartNew();

            Task bikinRoti = BikinRoti();
            Task bikinKopi = BikinKopi();

            await Task.WhenAll(bikinRoti, bikinKopi);

            watch.Stop();
            double detik = Math.Round(Convert.ToDouble(watch.ElapsedMilliseconds) / 1000, 1);

            Console.WriteLine("Sarapan sudah siap");
            Console.WriteLine("Waktu selesai masak : " + detik + " detik");

            Console.ReadKey();
        }

        private static async Task BikinRoti()
        {
            List<Task> taskMasak = new List<Task>();
            Task masakTelor = Task.Run(() => metod.MasakTelor());
            Task potongSayur = Task.Run(() => metod.PotongSayur());
            Task panggangRoti = Task.Run(() => metod.PanggangRoti());

            taskMasak.Add(masakTelor);
            taskMasak.Add(potongSayur);
            taskMasak.Add(panggangRoti);

            Task bikinRoti = Task.WhenAll(taskMasak);

            await bikinRoti;

            Task susunRoti = Task.Run(() =>  metod.SusunRoti());

            await susunRoti;
        }

        private static async Task BikinKopi()
        {
            Task bikinKopi = Task.Run(() => metod.MasakKopi());
            await bikinKopi;
            Task tuangKopi = Task.Run(() => metod.TuangKopi());
            await tuangKopi;
        }
    }
}
