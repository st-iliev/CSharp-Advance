using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Retake_Exam___18_August_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guest = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wasteFood = 0;
            int currentGuest = 0;
            while (guest.Count > 0 && plates.Count > 0)
            {
                if (currentGuest == 0)
                {
                currentGuest = guest.Peek();
                }
                int currentPlate = plates.Peek();
                if (currentGuest > currentPlate)
                {
                    currentGuest -= currentPlate;
                    currentPlate = 0;
                    plates.Pop();
                }
                else if (currentGuest == currentPlate)
                {
                    guest.Dequeue();
                    plates.Pop();
                    currentGuest = 0;
                    currentPlate = 0;
                }
                else if (currentGuest < currentPlate)
                {
                    wasteFood += currentPlate - currentGuest;
                    currentGuest = 0;
                    guest.Dequeue();
                    plates.Pop();
                }
            }
            if (guest.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ",guest)}");
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {wasteFood}");
        }
    }
}
