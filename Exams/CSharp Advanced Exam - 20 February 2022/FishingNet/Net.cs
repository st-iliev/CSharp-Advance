using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;
        private string material;
        private int capacity;
        private int count;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public List<Fish> Fish => (List<Fish>) this.fish;
        public string Material { get { return material; } set { material = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count => fish.Count;
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            else if (fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            else if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            Fish removeFish = fish.FirstOrDefault(s => s.Weight == weight);
            if (removeFish != null)
            {
                Fish.Remove(removeFish);
                return true;
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            Fish searchFish = Fish.FirstOrDefault(s => s.FishType == fishType);
            return searchFish;
        }
        public Fish GetBiggestFish()
        {
            Fish longestFish = Fish.OrderByDescending(s=>s.Length).First();
            return longestFish;
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Into the {this.Material}:");

            foreach (var item in Fish.OrderByDescending(s => s.Length))
            {
                report.AppendLine(item.ToString());
            }
            return report.ToString().TrimEnd();
        }


    }
}
