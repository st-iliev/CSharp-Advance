using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> allDigit = Enumerable.Range(1, num).ToList();
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<Predicate<int>> filtredNumbers = new List<Predicate<int>>();
            foreach (var item in numbers)
            {
                filtredNumbers.Add(s => s % item == 0);

            }
            foreach (var number in allDigit)
            {
                bool isDivide = true;
                foreach (var item in filtredNumbers)
                {
                    if (!item(number))
                    {
                        isDivide = false;
                        break;
                    }
                }
                if (isDivide)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
