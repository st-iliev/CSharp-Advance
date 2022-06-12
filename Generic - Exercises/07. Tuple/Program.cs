using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = $"{personInfo[0]} {personInfo[1]}";
            Tupe<string, string> firstPerson = new Tupe<string, string>(personName,personInfo[2]);
            string[] name = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tupe<string, int> secondPerson = new Tupe<string, int>(name[0], int.Parse(name[1]));
            double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Tupe<int, double> thirdPerson = new Tupe<int, double>((int)numbers[0], numbers[1]);
            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);
        }
    }
}
