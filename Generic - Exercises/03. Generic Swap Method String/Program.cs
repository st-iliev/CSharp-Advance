using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lineOfText = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < lineOfText; i++)
            {
                string line =Console.ReadLine();
                list.Add(line);
            }
                var box = new Box<string>(list);
            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);

        }
    }
}
