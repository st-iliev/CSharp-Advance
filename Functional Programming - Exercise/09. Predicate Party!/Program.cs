using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commingPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="Party!")
            {
                if (command[0] == "Double")
                {
                    List<string> doubleNames = commingPeople.FindAll(GetPredicate(command[1], command[2])).ToList();
                    if (!doubleNames.Any())
                    {
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    int index = commingPeople.FindIndex(GetPredicate(command[1], command[2]));
                    commingPeople.InsertRange(index, doubleNames);
                }
                else if (command[0] == "Remove")
                {
                    commingPeople.RemoveAll(GetPredicate(command[1], command[2]));
                }
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (commingPeople.Count > 0)
            {
                Console.Write($"{string.Join(", ",commingPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string start, string value)
        {
            if (start == "StartsWith")
            {
                return s => s.StartsWith(value);
            }
            else if (start == "EndsWith")
            {
                return s => s.EndsWith(value);
            } 
                return s => s.Length == int.Parse(value);
        }
    }
}
