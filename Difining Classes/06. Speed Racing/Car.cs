using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKilometer { get; set; }
        public decimal TravelledDistance { get; set; }
        public void CarMoves(decimal distance)
        {
            if (distance * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
    
}
