using System;
using System.Collections.Generic;

namespace Sets_and_Dictionaries_Advanced___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfNames = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();
            for (int i = 0; i < numbersOfNames; i++)
            {
                uniqueNames.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join("\n",uniqueNames));
        }
    }
}
