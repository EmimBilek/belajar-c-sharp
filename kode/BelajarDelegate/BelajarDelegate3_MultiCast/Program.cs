using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarDelegate3_MultiCast
{
    public delegate void Operasi(double a, double b);
    class Program
    {
        static void Main(string[] args)
        {
            Operasi op = null;
            op += Tambah;
            op += Kurang;
            op += Kali;
            op += Bagi;
            op += SisaBagi;

            Console.WriteLine("HASIL OPERASI 2 ANGKA");
            try
            {
                Console.Write("Masukkan angka pertama : ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan angka kedua : ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                op(a, b);

                Console.WriteLine();
                Console.WriteLine("Terimakasih sudah menggunakan aplikasi kami");
            }
            catch (FormatException)
            {
                Console.WriteLine("Gw bilang angka kocak, yang bener weh");
            }

            Console.ReadKey();
        }

        static void Tambah(double a, double b)
        {
            Console.WriteLine($"Hasil penambahan dari {a} dan {b} adalah {a + b}");
        }
        static void Kurang(double a, double b)
        {
            Console.WriteLine($"Hasil pengurangan dari {a} dan {b} adalah {a - b}");
        }
        static void Kali(double a, double b)
        {
            Console.WriteLine($"Hasil perkalian dari {a} dan {b} adalah {a * b}");
        }
        static void Bagi(double a, double b)
        {
            Console.WriteLine($"Hasil pembagian dari {a} dan {b} adalah {a / b}");
        }
        static void SisaBagi(double a, double b)
        {
            Console.WriteLine($"Hasil sisa pembagian dari {a} dan {b} adalah {a % b}");
        }
    }
}
