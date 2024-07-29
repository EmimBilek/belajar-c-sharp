using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarDelegate1_Pengenalan
{
    class Program
    {
        delegate void LogDel(string nama);
        static void Main(string[] args)
        {
            LogDel log1 = new LogDel(textIntroduction);
            LogDel log2 = new LogDel(textTenge);

            Console.Write("Masukkan nama kamu : ");
            string nama = Console.ReadLine();

            printTextWithDel(log2, nama);

            Console.ReadKey();
        }

        static void printTextWithDel(LogDel log, string text)
        {
            log(text);
        }

        static void textIntroduction(string nama)
        {
            string text = DateTime.Now.Minute > 0 ? $"Halo ges Nama aku {nama}, sekarang jam {DateTime.Now.Hour} lewat {DateTime.Now.Minute} menit" : $"Halo ges Nama aku {nama}, sekarang jam {DateTime.Now.Hour} pas";

            Console.WriteLine(text);
        }

        static void textTenge(string name)
        {
            Console.Write("Mau tau gak nama aku siapa? (Y/N): ");
            string answer = Console.ReadLine().ToLower();
            if (answer.Equals("y"))
            {
                Console.WriteLine("Dasar kepoo");
            }
            else
            {
                Console.WriteLine("Okeh. babay");
            }
        }
    }
}
