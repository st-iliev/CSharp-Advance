using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> collection;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            collection = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Employee> Collection => collection;
        public int Count => collection.Count;
        public void Add(Employee employee)
        {
            if (Count + 1 <= Capacity)
            {
                collection.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = collection.Where(s => s.Name == name).FirstOrDefault();
            if (employee != null)
            {
                return collection.Remove(employee);
            }
            return false;
        }
        public Employee GetOldestEmployee() => collection.OrderByDescending(s => s.Age).FirstOrDefault();
        public Employee GetEmployee(string name) => collection.Where(s => s.Name == name).FirstOrDefault();
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in collection)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
