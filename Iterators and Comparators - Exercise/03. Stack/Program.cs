using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> collection = new Stack<string>();
            string[] command = Console.ReadLine().Split(", ");
            while (command[0] != "END")
            {
                if (command[0].StartsWith("Push"))
                {
                    string firstElement = command[0].Substring(command[0].Length - 1);
                    command[0] = firstElement;
                    collection.Push(command.ToArray());
                }
                else if (command[0] == "Pop")
                {
                    try
                    {
                        collection.Pop();
                    }
                    catch (ArgumentException msg)
                    {

                        Console.WriteLine(msg.Message);
                    }
                }
                command = Console.ReadLine().Split(", ");
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
