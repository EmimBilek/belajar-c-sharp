using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetodeMasak
{
    public class MetodeMasakSarapan
    {
        private Random random;

        public MetodeMasakSarapan()
        {
            random = new Random();
        }

        public void MasakTelor()
        {
            Console.WriteLine("Sedang masak telor...");
            int milidetik = random.Next(6000, 7000);
            Thread.Sleep(milidetik);
            Console.WriteLine("Masak telor selesai!");
        }
        public void MasakKopi()
        {
            Console.WriteLine("Sedang bikin kopi...");
            int milidetik = random.Next(20000, 21000);
            Thread.Sleep(milidetik);
            Console.WriteLine("Bikin kopi selesai!");
        }
        public void PanggangRoti()
        {
            Console.WriteLine("Sedang panggang roti...");
            int milidetik = random.Next(9000, 12000);
            Thread.Sleep(milidetik);
            Console.WriteLine("Panggang roti selesai!");
        }
        public void PotongSayur()
        {
            Console.WriteLine("Sedang potong sayur...");
            int milidetik = random.Next(3000, 5000);
            Thread.Sleep(milidetik);
            Console.WriteLine("Potong sayur selesai!");
        }
        public void SusunRoti()
        {
            Console.WriteLine("Sedang susun roti...");
            int detik = random.Next(3000, 5000);
            Thread.Sleep(detik);
            Console.WriteLine("Susun roti selesai!");
        }
        public void TuangKopi()
        {
            Console.WriteLine("Sedang tuang kopi...");
            int detik = random.Next(1000, 2000);
            Thread.Sleep(detik);
            Console.WriteLine("Tuang kopi selesai!");
        }
    }
}
