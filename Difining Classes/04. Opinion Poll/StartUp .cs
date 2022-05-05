using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int numberOfPerson = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPerson; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }
            foreach (var item in persons.Where(s=>s.Age>30).OrderBy(s=>s.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
