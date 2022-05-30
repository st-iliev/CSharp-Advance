using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    stack.Pop();
                }
                else if (command[0] == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"{stack.Max()}");
                }
                else if (command[0] == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"{stack.Min()}");
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
