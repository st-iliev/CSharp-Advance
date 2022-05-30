using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            bool isFound = false;
            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }
            int minNumber = int.MaxValue;
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            foreach (var item in stack)
            {
                if (item < minNumber)
                {
                    minNumber = item;
                }
                if (item == input[2])
                {
                    isFound = true;
                    Console.WriteLine("true");
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine(minNumber);

            }


        }
    }
}
