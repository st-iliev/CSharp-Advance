using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            Dictionary<int, int> digits = new Dictionary<int, int>();
            for (int i = 0; i < numbers; i++)
            {
                int currentDigit = int.Parse(Console.ReadLine());
                if (!digits.ContainsKey(currentDigit))
                {
                    digits.Add(currentDigit,1);
                }
                else
                {
                    digits[currentDigit] += 1;
                }
            }
            foreach (var item in digits.Where(s=>s.Value%2==0 & s.Value!=1))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
