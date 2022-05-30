using System;
using System.Collections.Generic;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            int minNumber = int.MaxValue;
            bool isFound = false;
            foreach (var item in queue)
            {
                if (item < minNumber)
                {
                    minNumber = item;
                }
                if (item == input[2])
                {
                    isFound = true;
                    Console.WriteLine("true");
                    return;
                }
            }
            if (!isFound)
            {
                Console.WriteLine(minNumber);
            }
        }
    }
}
