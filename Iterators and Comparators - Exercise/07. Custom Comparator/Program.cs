using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, int, int> sortedNumbers = (n1, n2) =>
              {
                  if (n1 % 2 == 0 && n2 % 2 != 0)
                  {
                      return -1;
                  }
                  else if (n1 % 2 != 0 && n2 % 2 == 0)
                  {
                      return 1;
                  }
                  else if ( n1 > n2)
                  {
                      return 1;
                  }
                  else if (n1 < n2)
                  {
                      return -1;
                  }
                  else
                  {
                      return 0;
                  }
              };
            Array.Sort(numbers, (n1, n2) => sortedNumbers(n1, n2));
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
