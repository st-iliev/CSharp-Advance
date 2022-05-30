using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfElements = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < numbersOfElements; i++)
            {
                string[] currentElements = Console.ReadLine().Split();
                for (int r = 0; r < currentElements.Length; r++)
                {
                    elements.Add(currentElements[r]);
                }
            }
            Console.WriteLine(string.Join(" ",elements.OrderBy(s=>s)));
        }
    }
}
