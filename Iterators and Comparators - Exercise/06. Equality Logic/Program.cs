using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedSet<Person> sortedPerson = new SortedSet<Person>();
            HashSet<Person> hashPerson = new HashSet<Person>();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                Person newPerson = new Person(name,age);
                sortedPerson.Add(newPerson);
                hashPerson.Add(newPerson);
            }
            Console.WriteLine(sortedPerson.Count);
            Console.WriteLine(hashPerson.Count);
            
        }
    }
}
