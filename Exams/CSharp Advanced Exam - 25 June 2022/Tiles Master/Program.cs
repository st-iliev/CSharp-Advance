using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> tiles = new Dictionary<string, int>();
            tiles.Add("Countertop", 0);
            tiles.Add("Floor", 0);
            tiles.Add("Oven", 0);
            tiles.Add("Sink", 0);
            tiles.Add("Wall", 0);
            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {

                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();
                if (currentWhite == currentGrey)
                {
                    int sum = currentWhite + currentGrey;
                    if (sum == 40)
                    {
                        tiles["Sink"]++;
                    }
                    else if (sum == 50)
                    {
                        tiles["Oven"]++;
                    }
                    else if (sum == 60)
                    {
                        tiles["Countertop"]++;
                    }
                    else if (sum == 70)
                    {
                        tiles["Wall"]++;
                    }
                    else
                    {
                        tiles["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(currentWhite / 2);
                    greyTiles.Enqueue(currentGrey);
                }
            }
            if (whiteTiles.Count > 0)
            {
            Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }
            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }
            foreach (var item in tiles.Where(s=>s.Value > 0).OrderByDescending(s=>s.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
