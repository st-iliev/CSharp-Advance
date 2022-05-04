using System;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int numberOfPersons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                Person person = new Person(name,age);
                family.AddMember(person);
            }
            Person oldestPerson = family.GetOlderstMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
