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
            string city = personInfo[3];
            if (personInfo.Length > 4)
            {
            city = $"{personInfo[3]} {personInfo[4]}";
            }
            Threeuple<string, string,string> firstPerson = new Threeuple<string, string,string>(personName,personInfo[2], city);

            string[] name = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var isDrunk = name[2] == "drunk" ? true : false;
            Threeuple<string, int,bool> secondPerson = new Threeuple<string, int,bool>(name[0], int.Parse(name[1]), isDrunk);

            string[] bankAccountInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, double,string> thirdPerson = new Threeuple<string, double,string>(bankAccountInfo[0], double.Parse(bankAccountInfo[1]), bankAccountInfo[2]);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);
        }
    }
}
