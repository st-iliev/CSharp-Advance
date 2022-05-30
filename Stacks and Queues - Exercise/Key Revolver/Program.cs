using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int inteligence = int.Parse(Console.ReadLine());
            int barrelCount = 0;
            int numberOfBullets = bullets.Count;
            while (bullets.Count>0 && locks.Count >0)
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    barrelCount++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    barrelCount++;
                }
                if (barrelCount == sizeOfGunBarrel && bullets.Count>0)
                {
                    Console.WriteLine($"Reloading!");
                    barrelCount = 0;
                }
            }
            if (locks.Count == 0 && bullets.Count >= 0)
            {
                int bulletCost = (numberOfBullets - bullets.Count)*pricePerBullet;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligence-bulletCost}");
            }
            else if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
