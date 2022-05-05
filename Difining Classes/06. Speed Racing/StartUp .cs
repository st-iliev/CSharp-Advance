using System;
using System.Linq;
using System.Collections.Generic;

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
                string[] currentCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = currentCar[0];
                decimal fuelAmount = decimal.Parse(currentCar[1]);
                decimal fuelper1Km = decimal.Parse(currentCar[2]);
                Car car = new Car();
                {
                    car.Model = model;
                    car.FuelAmount = fuelAmount;
                    car.FuelConsumptionPerKilometer = fuelper1Km;
                };
                cars.Add(car);
            }         
            string[] drive = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (drive[0]!="End")
            {
                string model = drive[1];
                decimal distance = decimal.Parse(drive[2]);
                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.CarMoves(distance);
                    }
                }
                drive = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TravelledDistance}");
            }
        }
    }
}
