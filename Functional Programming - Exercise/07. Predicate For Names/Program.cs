using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> nameFilter = (s, y) => s.Length <= y;
            List<string> result = names.Where(s => nameFilter(s, nameLenght)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,result));
        }
    }
}
