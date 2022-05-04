using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            int numberOfEngine = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < numberOfEngine; i++)
            {
                Engine engine = new Engine();
                string[] currentEngine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = currentEngine[0];
                int power = int.Parse(currentEngine[1]);
                if (currentEngine.Length > 2)
                {
                    if (char.IsDigit(currentEngine[2][0]))
                    {
                        int displacement = int.Parse(currentEngine[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = currentEngine[2];
                        engine.Efficiency = efficiency;
                    }
                }
                if (currentEngine.Length > 3)
                {
                    string efficiency = currentEngine[3];
                    engine.Efficiency = efficiency;
                }
                engine.Model = model;
                engine.Power = power;
                engines.Add(engine);
            }
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();
                string model = currentCar[0];
                string engine = currentCar[1];
                if (currentCar.Length > 2)
                {
                    if (char.IsDigit(currentCar[2][0]))
                    {
                        int weight = int.Parse(currentCar[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = currentCar[2];
                        car.Color = color;
                    }
                }
                if (currentCar.Length > 3)
                {
                    string color = currentCar[3];
                    car.Color = color;
                }
                car.Model = model;
                Engine findEngine = engines.FirstOrDefault(s => s.Model == engine);
                car.Engine = findEngine;
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");

                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                if (car.Engine.Displacement == null)
                {
                    Console.WriteLine($"   Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"   Displacement: {car.Engine.Displacement}");

                }
                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"   Efficiency: n/a ");
                }
                else
                {
                    Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                }
                if (car.Weight == null)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                if (car.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
