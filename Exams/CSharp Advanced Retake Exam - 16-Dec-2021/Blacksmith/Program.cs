using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Retake_Exam___16_Dec_2021
{
    class Program
    {

        static void Main(string[] args)
        {
            Queue<int> steels = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();
            while (steels.Count > 0 && carbon.Count > 0)
            {
                int currentCarbon = carbon.Peek();
                int sum = steels.Peek() + currentCarbon;
                if (sum == 70)
                {
                    RemoveMaterial(steels, carbon);
                    ForgedSwords(forgedSwords, "Gladius");
                }
                else if (sum == 80)
                {
                    RemoveMaterial(steels, carbon);
                    ForgedSwords(forgedSwords, "Shamshir");
                }
                else if (sum == 90)
                {
                    RemoveMaterial(steels, carbon);
                    ForgedSwords(forgedSwords, "Katana");
                }
                else if (sum == 110)
                {
                    RemoveMaterial(steels, carbon);
                    ForgedSwords(forgedSwords, "Sabre");
                }
                else if (sum == 150)
                {
                    RemoveMaterial(steels, carbon);
                    ForgedSwords(forgedSwords, "Broadsword");
                }
                else
                {
                    RemoveMaterial(steels, carbon);
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);

                }
            }
            if (forgedSwords.Values.Sum() > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            if (steels.Count == 0)
            {
                Console.WriteLine($"Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steels)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine($"Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var item in forgedSwords.OrderBy(s=>s.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
        
        public static void RemoveMaterial(Queue<int> steels, Stack<int> carbon)
        {
            steels.Dequeue();
            carbon.Pop();
        }
        public static void ForgedSwords(Dictionary<string, int> listOfSwords,string sword)
        {
            if (!listOfSwords.ContainsKey(sword))
            {
                listOfSwords.Add(sword, 1);
            }
            else
            {
                listOfSwords[sword] += 1;
            }
        }
    }
}
