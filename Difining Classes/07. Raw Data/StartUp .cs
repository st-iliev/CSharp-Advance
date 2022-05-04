using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCar = Console.ReadLine().Split();
                string model = currentCar[0];
                int speed = int.Parse(currentCar[1]);
                int power = int.Parse(currentCar[2]);
                int weigh = int.Parse(currentCar[3]);
                string type = currentCar[4];
                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weigh);
                Tire[] tires = new Tire[4];
                int count = 0;
                for (int r = 5; r < 12; r+=2)
                {
                    double preassure = double.Parse(currentCar[r]);
                    int age = int.Parse(currentCar[r+1]);
                    Tire tire = new Tire(age, preassure);
                    tires[count++] = tire;
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var item in cars)
                {
                    if (item.Cargo.Type == "fragile")
                    {
                        if (item.Tire.Any(s => s.Pressure < 1))
                        {
                            Console.WriteLine(item.Model);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in cars)
                {
                    if (item.Cargo.Type == "flammable")
                    {
                        if (item.Engine.Power >250)
                        {
                            Console.WriteLine(item.Model);
                        }
                    }
                }
            }
        }
    }
}
