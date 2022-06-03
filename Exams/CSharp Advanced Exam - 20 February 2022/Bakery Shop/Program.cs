using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Advanced_Exam___20_February_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));
            SortedDictionary<string, int> products = new SortedDictionary<string, int>();
            while (water.Count > 0 && flour.Count > 0)
            {

                double calc = water.Peek() + flour.Peek();
                double calcWater = (water.Peek() * 100) / calc;
                double calcFlour = (flour.Peek() * 100) / calc;
                if (calcWater == 50 && calcFlour == 50)
                {
                    if (!products.ContainsKey("Croissant"))
                    {
                        products.Add("Croissant", 1);
                    }
                    else
                    {
                        products["Croissant"] += 1;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calcWater == 40 && calcFlour == 60)
                {
                    if (!products.ContainsKey("Muffin"))
                    {
                        products.Add("Muffin", 1);
                    }
                    else
                    {
                        products["Muffin"] += 1;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calcWater == 30 && calcFlour == 70)
                {
                    if (!products.ContainsKey("Baguette"))
                    {
                        products.Add("Baguette", 1);
                    }
                    else
                    {
                        products["Baguette"] += 1;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calcWater == 20 && calcFlour == 80)
                {
                    if (!products.ContainsKey("Bagel"))
                    {
                        products.Add("Bagel", 1);
                    }
                    else
                    {
                        products["Bagel"] += 1;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double currentWater = water.Peek();
                    double currentFlour = flour.Peek();
                    if (water.Peek() > flour.Peek())
                    {
                        calcWater = calcFlour;
                        currentWater -= currentFlour;
                        water.Dequeue();
                        flour.Pop();
                        water.Enqueue(currentWater);
                    }
                    else
                    {
                        calcFlour = calcWater;
                        currentFlour -= currentWater;
                        water.Dequeue();
                        flour.Pop();
                        flour.Push(currentFlour);
                    }
                    if (!products.ContainsKey("Croissant"))
                    {
                        products.Add("Croissant", 1);
                    }
                    else
                    {
                        products["Croissant"] += 1;
                    }

                }

            }
            foreach (var item in products.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (water.Count > 0)
            {
                Console.Write($"Water left: ");
                Console.Write(string.Join(", ", water));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Water left: None");
            }
            if (flour.Count > 0)
            {
                Console.Write($"Flour left: ");
                Console.Write(string.Join(", ", flour));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Flour left: None");
            }
        }
    }
}
