using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            int divideDigit = int.Parse(Console.ReadLine());
            Predicate<int> divisibleDigit= s => s % divideDigit != 0;
            List<int> result = input.FindAll(divisibleDigit);
            Console.WriteLine(string.Join(" ", result));


        }
    }
}
