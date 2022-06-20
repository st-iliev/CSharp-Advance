using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Exam___26_June_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredient = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> cook = new Dictionary<string, int>();
            cook.Add("Chocolate cake", 0);
            cook.Add("Dipping sauce", 0);
            cook.Add("Green salad", 0);
            cook.Add("Lobster", 0);
            while (ingredient.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredient.Dequeue();
                if (currentIngredient == 0)
                {
                    if (ingredient.Count == 0)
                    {
                        break;
                    }
                    continue;
                }
                int currentFreshness = freshness.Pop();
                int sum = currentFreshness * currentIngredient;
               
                if (sum == 150)
                {
                    cook["Dipping sauce"] += 1;
                }
                else if (sum == 250)
                {
                    cook["Green salad"] += 1;
                }
                else if (sum == 300)
                {
                    cook["Chocolate cake"] += 1;
                }
                else if (sum == 400)
                {
                    cook["Lobster"] += 1;
                }
                else
                {
                    ingredient.Enqueue(currentIngredient + 5);
                }
            }
            if (!cook.Any(s=>s.Value==0))
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
                foreach (var item in cook.OrderBy(s=>s.Key))
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }   
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
                if (ingredient.Count > 0)
                {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
                }
                foreach (var item in cook.OrderBy(s => s.Key))
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine($" # {item.Key} --> {item.Value}");
                    }
                }
            }
        }
    }
}
