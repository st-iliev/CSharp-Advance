using System;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cloths = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rack = int.Parse(Console.ReadLine());           
            int rackCount = 0;
            int sum = 0;
            while(cloths.Count > 0)
            {
                 sum += cloths.Peek();
                if (rack == sum)
                {
                    rackCount++;
                    sum = 0;
                    cloths.Pop();
                }
                else if (rack < sum)
                {
                    rackCount++;
                    sum = 0;
                }
                else
                {
                    cloths.Pop();
                }
            }
            if (sum > 0)
            {
                rackCount++;
            }
            Console.WriteLine(rackCount);
        }
    }
}
