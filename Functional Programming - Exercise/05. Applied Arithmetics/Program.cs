using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Action<int[]> add = digits =>
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    digits[i] += 1;
                }
            };
            Action<int[]> multiply = digits =>
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    digits[i] *= 2;
                }
            };
            Action<int[]> subtract = digits =>
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    digits[i] -= 1;
                }
            };
            Action<int[]> printNumbers = s => Console.WriteLine(string.Join(" ",s));

            while (command!="end")
            {
                if (command == "add")
                {
                    add(input);
                }
                else if (command == "multiply")
                {
                    multiply(input);
                }
                else if (command == "subtract")
                {
                    subtract(input);
                }
                else if (command == "print")
                {
                    printNumbers(input);
                }
                command = Console.ReadLine();
            }
                   
        }
    }
}
