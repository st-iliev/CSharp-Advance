using System;
using System.Collections.Generic;
using System.Linq;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentBottle = bottles.Peek();
                int currentCup = cups.Peek();
                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    bottles.Pop();
                    cups.Dequeue();
                }
                else
                {
                    while (currentCup>0)
                    {
                        currentCup -= currentBottle;
                        bottles.Pop();
                        if (bottles.Count == 0)
                        {
                            break;
                        }
                        currentBottle = bottles.Peek();
                        if (currentBottle >= currentCup)
                        {
                            wastedWater += currentBottle - currentCup;
                            currentCup = 0;
                            bottles.Pop();
                            cups.Dequeue();
                        }
                    }
                }
            }
            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            else if (cups.Count>0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
