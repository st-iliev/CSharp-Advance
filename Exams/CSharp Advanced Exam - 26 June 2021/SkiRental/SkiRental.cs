using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        
        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Ski ski)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            int count = data.Count;
            data = data.Where(s => s.Manufacturer != manufacturer || s.Model != model).ToList();
            if (data.Count == count)
            {
                return false;
            }
            return true;
        }
        public Ski GetNewestSki()
        {
            Ski newestSki = data.OrderByDescending(s => s.Year).FirstOrDefault();
            if (newestSki == null)
            {
                return null;
            }
            return newestSki;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski currentSki = data.Where(s => s.Manufacturer == manufacturer && s.Model == model).FirstOrDefault();
            if (currentSki == null)
            {
                return null;
            }
            return currentSki;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
