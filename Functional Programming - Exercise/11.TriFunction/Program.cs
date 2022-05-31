using System;
using System.Linq;

namespace _11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> biggerOrEqualToSum = (names, sum) => names.Sum(s => s) >= sum;
            Func<string[], int, Func<string, int, bool>, string> findName = (names, sum, biggerOrEqualToSum) => names.Where(s => biggerOrEqualToSum(s, sum)).FirstOrDefault();
            string rightName = findName(names, sum, biggerOrEqualToSum);
            Console.WriteLine(rightName);
        }
    }
}   
