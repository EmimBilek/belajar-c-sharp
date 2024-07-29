using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarDelegate2_CovarianceContravariance
{
    class Program
    {
        delegate Car CarFactoryDel(int id, string name);
        delegate void LogEVCarDel(EVCar ev);
        delegate void LogICECarDel(ICECar ice);
        static void Main(string[] args)
        {
            CarFactoryDel carFDel = CarFactory.ReturnEVCar; //kofarians

            Car evCar = carFDel(1, "Tesla X-Model");

            //Console.WriteLine($"Obejct Type : {evCar.GetType()}");
            //Console.WriteLine($"Car Detail : {evCar.GetCarDetails()}");

            LogEVCarDel logEvCar = LogCarDetails;

            carFDel = CarFactory.ReturnICECar; //kofarians

            Car iceCar = carFDel(2, "Nissan GTR Skyline");

            LogICECarDel logIceCar = LogCarDetails;

            logEvCar(iceCar as EVCar); //kontrafarians

            Console.WriteLine();

            logIceCar(evCar as ICECar); //kontrafarians
            //Console.WriteLine($"Obejct Type : {iceCar.GetType()}");
            //Console.WriteLine($"Car Detail : {iceCar.GetCarDetails()}");

            Console.ReadKey();
        }

        static void LogCarDetails(Car car) //kontrafarians method yang di delegasi
        {
            if (car is EVCar)
            {
                Console.WriteLine("Aku suka mobil listrik");
                Console.WriteLine($"Obejct Type : {car.GetType()}");
                Console.WriteLine($"Car Detail : {car.GetCarDetails()}");
            }
            else if (car is ICECar)
            {
                Console.WriteLine("Aku suka mobil mesin knalpot");
                Console.WriteLine($"Obejct Type : {car.GetType()}");
                Console.WriteLine($"Car Detail : {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public abstract class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual string GetCarDetails()
        {
            return $"{id}. {name}";
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { id = id, name = name };
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { id = id, name = name };
        }
    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combust Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }
}
