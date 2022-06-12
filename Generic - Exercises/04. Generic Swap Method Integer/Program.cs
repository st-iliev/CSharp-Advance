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
            List<int> list = new List<int>();
            for (int i = 0; i < lineOfText; i++)
            {
                int line =int.Parse(Console.ReadLine());
                list.Add(line);
            }
                var box = new Box<int>(list);
            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);

        }
    }
}
