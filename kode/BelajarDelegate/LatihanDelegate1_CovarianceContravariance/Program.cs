using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanDelegate1_CovarianceContravariance
{

    //class Program //program kofarians
    //{
    //    delegate Animal GetAnimalDel(int leg);
    //    static void Main(string[] args)
    //    {
    //        GetAnimalDel getAnimalDel = GetAnimal.GetChicken;

    //        Animal chicken = getAnimalDel(2); //kofarians

    //        getAnimalDel = GetAnimal.GetCat;

    //        Animal cat = getAnimalDel(4);

    //        Console.WriteLine($"i'm a chicken, i have {chicken.leg} leg. \"{chicken.Sound()}\"");
    //        Console.WriteLine();
    //        Console.WriteLine($"i'm a Cat, i have {cat.leg} leg. \"{cat.Sound()}\"");

    //        Console.ReadKey();
    //    }
    //}
    class Program //program kofarians
    {
        delegate Animal GetAnimalDel(int leg);
        delegate void CatSound(Cat cat);
        delegate void ChickenSound(Chicken chicken);
        static void Main(string[] args)
        {
            GetAnimalDel getAnimalDel = GetAnimal.GetChicken;

            Animal chicken = getAnimalDel(2); //kofarians, Class Animal mengambil value kelas yang lebih spesifik, yaitu Chicken

            getAnimalDel = GetAnimal.GetCat;

            Animal cat = getAnimalDel(4);//kofarians, Class Animal mengambil value kelas yang lebih spesifik, yaitu Cat

            Console.WriteLine($"i'm a chicken, i have {chicken.leg} leg.");
            ChickenSound chickenSound = animalSound; //kontrafarians, parameter delegate (Chicken chicken) merupakan derivedClass dari parameter method yang di delegasi (Animal animal)
            chickenSound(chicken as Chicken); //kontrafarians, menggunakan variable Class Animal "chicken" sebagai argumen yang dilemparkan ke parameter (Chicken chiken) yang merupakan Class Chicken pada delegate ChickenSound

            Console.WriteLine();
            Console.WriteLine($"i'm a Cat, i have {cat.leg} leg.");
            CatSound catSound = animalSound;//kontrafarians, parameter delegate (Cat cat) merupakan derivedClass dari parameter method yang di delegasi (Animal animal)
            catSound(cat as Cat);//kontrafarians, menggunakan variable Class Animal "cat" sebagai argumen yang dilemparkan ke parameter (Cat cat) yang merupakan Class Cat pada delegate CatSound

            Console.ReadKey();
        }
        static void animalSound(Animal animal)
        {
            if (animal is Cat)
            {
                Console.WriteLine("Miauuww");
            }
            else if (animal is Chicken)
            {
                Console.WriteLine("Pekookkkk");
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }

    public static class GetAnimal
    {
        public static Chicken GetChicken(int leg)
        {
            return new Chicken{ leg = 2};
        }

        public static Cat GetCat(int leg)
        {
            return new Cat { leg = 4 };
        }
    }

    public abstract class Animal
    {
        public int leg { get; set; }
        public virtual string Sound()
        {
            return "My voice was variatif";
        }
    }

    public class Cat : Animal
    {
        public override string Sound()
        {
            return "Miauww";
        }
    }

    public class Chicken : Animal
    {
        public override string Sound()
        {
            return "Pekoookkk";
        }
    }
}
