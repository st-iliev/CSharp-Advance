using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < elements; i++)
            {
                string currentElement =Console.ReadLine();
                list.Add(currentElement);
            }
            string elementCompare = Console.ReadLine();
            var box = new Box<string>(list);
            int count = box.CountOfElemenets(list, elementCompare);
            Console.WriteLine(count);

        }
    }
}
