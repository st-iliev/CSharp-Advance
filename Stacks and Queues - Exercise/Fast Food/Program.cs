using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int biggestOrder = int.MinValue;
            int count = 0;
           while(orders.Count>0)
            {
                if (quantity <= 0)
                {
                    break;
                }
                int currentOrder = orders.Peek();
                if (biggestOrder < currentOrder)
                {
                    biggestOrder = currentOrder;
                }
                if (quantity - currentOrder >= 0)
                { 
                    quantity -= currentOrder;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (biggestOrder != int.MinValue)
            {
            Console.WriteLine(biggestOrder);
            }
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
