using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();
            string forceSide = Console.ReadLine();
            while (forceSide != "Lumpawaroo")
            {
                string side = "";
                string user = "";
                if (forceSide.Contains(" | "))
                {
                    side = forceSide.Split(" | ")[0];
                    user = forceSide.Split(" | ")[1];
                    if (!force.ContainsKey(side))
                    {
                        force.Add(side, new List<string>());
                    }
                    if (!force.Any(s => s.Value.Contains(user)))
                    {
                        force[side].Add(user);
                    }
                }
                else if (forceSide.Contains(" -> "))
                {
                    user = forceSide.Split(" -> ")[0];
                    side = forceSide.Split(" -> ")[1];
                    if (!force.ContainsKey(side))
                    {
                        force.Add(side, new List<string>());
                    }
                    if (!force.Any(s => s.Value.Contains(user)))
                    {
                        force[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        if (!force[side].Contains(user))
                        {
                            foreach (var item in force.Values)
                            {
                                if (item.Contains(user))
                                {
                                    item.Remove(user);
                                }
                            }
                            force[side].Add(user);
                            Console.WriteLine($"{user} joins the {side} side!");
                        }
                    }
                }
              
                forceSide = Console.ReadLine();
            }
            foreach (var item in force.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                if (item.Value.Count == 0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var kvp in item.Value.OrderBy(s=>s))
                {
                    Console.WriteLine($"! {kvp}");
                }
            }
        }
    }
}
