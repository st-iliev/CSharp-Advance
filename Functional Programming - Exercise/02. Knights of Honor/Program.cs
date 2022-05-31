using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> print = names => Console.WriteLine($"Sir {string.Join("\nSir ",names)}");
            print(input);

        }
    }
}
