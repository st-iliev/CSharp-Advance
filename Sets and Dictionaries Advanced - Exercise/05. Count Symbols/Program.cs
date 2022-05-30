using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> occurrencesChar = new SortedDictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrencesChar.ContainsKey(input[i]))
                {
                    occurrencesChar.Add(input[i], 1);
                }
                else
                {
                    occurrencesChar[input[i]] += 1;
                }
            }
            foreach (var item in occurrencesChar)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
