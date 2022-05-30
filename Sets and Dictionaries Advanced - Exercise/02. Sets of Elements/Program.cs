using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setLength = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> nNumbers = new HashSet<int>();
            HashSet<int> mNumbers = new HashSet<int>();
            for (int i = 0; i < setLength[0]; i++)
            {
                nNumbers.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < setLength[1]; i++)
            {
                mNumbers.Add(int.Parse(Console.ReadLine()));
            }
            Console.Write(string.Join(" ", nNumbers.Where(s =>mNumbers.Any(s2 => s2 == s))));
        }
    }
}
