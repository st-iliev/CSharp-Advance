using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquits = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> cooks = new Dictionary<string, int>();
            cooks.Add("Bread", 0);
            cooks.Add("Cake", 0);
            cooks.Add("Pastry", 0);
            cooks.Add("Fruit Pie", 0);
            while (liquits.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquits = liquits.Dequeue();
                int currentIngredients = ingredients.Pop();
                int sum = currentLiquits + currentIngredients;
                if (sum == 25)
                {
                    cooks["Bread"] ++;
                }
                else if (sum == 50)
                {
                    cooks["Cake"] ++;
                }
                else if (sum == 75)
                {
                    cooks["Pastry"] ++;
                }
                else if (sum == 100)
                {
                    cooks["Fruit Pie"] ++;
                }
                else
                {
                    ingredients.Push(currentIngredients + 3);
                }
            }
            if (!cooks.Any(s => s.Value == 0))
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquits.Count <= 0)
            {
                Console.WriteLine($"Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquits)}");
            }
            if (ingredients.Count <= 0)
            {
                Console.WriteLine($"Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            foreach (var item in cooks.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
