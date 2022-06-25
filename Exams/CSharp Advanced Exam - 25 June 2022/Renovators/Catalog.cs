using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }
        public IReadOnlyCollection<Renovator> Renovators => renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => Renovators.Count;
        public string AddRenovator(Renovator renovator)
       {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            
            else if (Count + 1 > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator removed = renovators.FirstOrDefault(s => s.Name == name);
            if (removed != null)
            {
                return renovators.Remove(removed);
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> removedRenovators = renovators.Where(s => s.Type == type).ToList();
            if (removedRenovators.Count > 0)
            {
                foreach (var item in removedRenovators)
                {
                    renovators.Remove(item);
                }
                return removedRenovators.Count;
            }
            else
            {
                return 0;
            }
        }
        public Renovator HireRenovator(string name)
        {
            foreach (var item in renovators)
            {
                if (item.Name == name)
                {
                    item.Hired = true;
                    return item;
                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> workedRenovators = renovators.Where(s => s.Days >=days ).ToList();
            return workedRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.Where(s => s.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
