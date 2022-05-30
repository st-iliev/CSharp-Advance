using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfColors = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> cloths = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < numberOfColors; i++)
            {
                string[] currentColor = Console.ReadLine().Split(" -> ");
                string color = currentColor[0];
                string[] currentCloths = currentColor[1].Split(",").ToArray();
                if (!cloths.ContainsKey(color))
                {
                    cloths.Add(color, new Dictionary<string, int>());
                }
                if (cloths.ContainsKey(color))
                {
                    for (int r = 0; r < currentCloths.Length; r++)
                    {
                        if (!cloths[color].ContainsKey(currentCloths[r]))
                        {
                            cloths[color].Add(currentCloths[r], 1);
                        }
                        else
                        {
                            cloths[color][currentCloths[r]] += 1;
                        }
                    }
                }
            }
            string[] searchedCloth = Console.ReadLine().Split();
            foreach (var color in cloths)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == searchedCloth[0] && cloth.Key == searchedCloth[1] )
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
