using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (currentPerson[0]!="END")
            {
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                string town = currentPerson[2];
                Person newPerson = new Person(name, age, town);
                persons.Add(newPerson);
                currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int nPerson = int.Parse(Console.ReadLine());
            Person comparePerson = persons[nPerson - 1];
            int countMatches =-1;
            int countNotEquals = 0;
            foreach (var item in persons)
            {
                if (persons[nPerson - 1].CompareTo(item) == 0)
                {
                    countMatches++;
                }
                else
                {
                    countNotEquals++;
                }
            }
            if (countMatches == 0)
            {
                Console.WriteLine($"No matches");
            }
            else
            {
            Console.WriteLine($"{countMatches+1} {countNotEquals} {persons.Count}");
            }
        }
    }
}
