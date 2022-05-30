using System;
using System.Collections.Generic;
using System.Text;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            StringBuilder simpleText = new StringBuilder();
            Stack<string> oldText = new Stack<string>();
            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "1")
                {
                    oldText.Push(simpleText.ToString());
                    simpleText.Append(command[1]);
                }
                else if (command[0] == "2")
                {
                    oldText.Push(simpleText.ToString());
                    int count = int.Parse(command[1]);
                    simpleText.Remove(simpleText.Length - count, count);
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine($"{simpleText[int.Parse(command[1]) - 1]}");
                }
                else if (command[0] == "4")
                {
                    simpleText = new StringBuilder(oldText.Pop());
                }
            }
        }
    }
}
