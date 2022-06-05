using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants => participants;
        public int Count => Participants.Count;
        public void Add(Car car)
        {
            string license = participants.Any(s => s.LicensePlate == car.LicensePlate).ToString();
            if (license == "False" && participants.Count + 1 <= Capacity && car.HorsePower <= MaxHorsePower)
            {
                participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car removeCar = participants.FirstOrDefault(s => s.LicensePlate == licensePlate);
            if (removeCar != null)
            {
                participants.Remove(removeCar);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car findCar = participants.FirstOrDefault(s => s.LicensePlate == licensePlate);
            if (findCar != null)
            {
                return findCar;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (participants.Count == 0)
            {
                return null;
            }
            else
            {
                Car mostPowerful = participants.OrderByDescending(s => s.HorsePower).First();
                return mostPowerful;
            }
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in participants)
            {
                report.AppendLine($"Make: {car.Make}");
                report.AppendLine($"Model: {car.Model}");
                report.AppendLine($"License Plate: {car.LicensePlate}");
                report.AppendLine($"Horse Power: {car.HorsePower}");
                report.AppendLine($"Weight: {car.Weight}");
            }
            return report.ToString().TrimEnd();
        }
    }
}
