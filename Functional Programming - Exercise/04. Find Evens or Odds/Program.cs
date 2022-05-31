using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> allNumbers = new List<int>();
            for (int i = rangeOfNumbers[0]; i <= rangeOfNumbers[1]; i++)
            {
                allNumbers.Add(i);
            }
            string command = Console.ReadLine();
            Predicate<int> evenDigit = s => s % 2 == 0;
            Predicate<int> oddDigit = s => s % 2 != 0;
            if (command == "odd")
            {
                List<int> oddNumbers = allNumbers.FindAll(oddDigit);
                Console.WriteLine(string.Join(" ",oddNumbers));
            }
            else
            {
                List<int> evenNumbers = allNumbers.FindAll(evenDigit);
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
        }
    }
}
