using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private  List<Drone> drones;
        public IReadOnlyCollection<Drone> Drones => drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => drones.Count;
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            drones = new List<Drone>();
        }
        public string AddDrone(Drone drone)

        {
            if (string.IsNullOrEmpty(drone.Brand) || string.IsNullOrEmpty(drone.Name))
            {
                return "Invalid drone.";
            }
            else if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (drones.Count + 1 > Capacity)
            {
                return "Airfield is full.";
            }
            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone removeDrone = drones.FirstOrDefault(s => s.Name == name);
            if (removeDrone != null)
            {
                drones.Remove(removeDrone);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            List<Drone> brandDrones = drones.Where(s => s.Brand == brand).ToList();
            if (brandDrones.Count > 0)
            {
                foreach (var dron in brandDrones)
                {
                    drones.Remove(dron);
                }
                return brandDrones.Count;
            }
            else
            {
                return 0;
            }   
        }
        public Drone FlyDrone(string name)
        {
            Drone flyDrone = drones.FirstOrDefault(s => s.Name == name);
            if (flyDrone != null)
            {
                int index = drones.IndexOf(flyDrone);
                drones[index].Available = false;
                return flyDrone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesWithRange = drones.Where(s => s.Range >= range).ToList();
            foreach (var dron in dronesWithRange)
            {
                int index = drones.IndexOf(dron);
                drones[index].Available = false;
            }
            return dronesWithRange;
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Drones available at {Name}:");
            foreach (var dron in drones)
            {
                if (dron.Available == true)
                {
                    report.AppendLine(dron.ToString());
                }
            }
            return report.ToString().TrimEnd();
        }
    }
}
