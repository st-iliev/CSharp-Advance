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
            List<double> list = new List<double>();
            for (int i = 0; i < elements; i++)
            {
                double currentElement =double.Parse(Console.ReadLine());
                list.Add(currentElement);
            }
            double elementCompare = double.Parse(Console.ReadLine());
            var box = new Box<double>(list);
            int count = box.CountOfElemenets(list, elementCompare);
            Console.WriteLine(count);

        }
    }
}
