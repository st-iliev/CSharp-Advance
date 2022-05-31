using System;
using System.Collections.Generic;

namespace Functional_Programming___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));
            print(input);
        }
    
    }
}
