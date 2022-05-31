using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> commands = Console.ReadLine().Split(";").ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            while (commands[0]!="Print")
            {
                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + commands[2], GetPredicate(commands[1], commands[2]));

                }
                else if (commands[0] == "Remove filter")
                {
                    filters.Remove(commands[1] + commands[2]);
                }
                    commands = Console.ReadLine().Split(";").ToList();
            }
            foreach (var (key,value) in filters)
            {
                names.RemoveAll(value);
            }
            Console.WriteLine(string.Join(" ",names));
        }

        private static Predicate<string> GetPredicate(string type, string parameter)
        {
            if (type == "Starts with")
            {
                return s => s.StartsWith(parameter);
            }
            else if (type == "Ends with")
            {
                return s => s.EndsWith(parameter);
            }
            else if (type == "Length")
            {
                return s => s.Length == int.Parse(parameter);
            }
            return s => s.Contains(parameter);
        }
    }
}
