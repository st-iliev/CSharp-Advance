using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> Cars;
        private int capacity;
        private int count;
        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>();
        }
        public int Count { get; set; }
        public int Capacity { get; set; }
        public string AddCar(Car Car)
        {
            bool isTrue = true;
            foreach (var item in Cars)
            {
                if (item.RegistrationNumber == Car.RegistrationNumber)
                {
                    isTrue = false;
                    return "Car with that registration number, already exists!";
                }
            }
            if (Cars.Count + 1 > Capacity)
            {
                isTrue = false;
                return "Parking is full!";
            }
            if  (isTrue)
            {
                Cars.Add(Car);
                Count++;
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
            return "";
        }
        public string RemoveCar(string RegistrationNumber)
        {
            bool isFound = false;
            foreach (var item in Cars)
            {
                if (item.RegistrationNumber == RegistrationNumber)
                {
                    isFound = true;
                   
                }
            }
            if (!isFound)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car removeCar = Cars.First(s => s.RegistrationNumber == RegistrationNumber);
                Cars.Remove(removeCar);
                Count--;
                return $"Successfully removed {RegistrationNumber}";
            }
        }
        public Car GetCar(string RegistrationNumber)
        {
            Car carFound = Cars.Find(s => s.RegistrationNumber == RegistrationNumber);
            return carFound;
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var reg in RegistrationNumbers)
            {
                RemoveCar(reg);
            }
        }
    }
}
