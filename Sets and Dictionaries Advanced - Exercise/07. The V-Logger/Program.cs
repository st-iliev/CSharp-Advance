using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._The_V_Logger
{


    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggerFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggerFollowing = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> vloggers = new Dictionary<string, List<int>>(2);

            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "Statistics")
            {
                if (commands[1] == "joined")
                {
                    if (!vloggerFollowers.ContainsKey(commands[0]))
                    {
                        vloggerFollowers.Add(commands[0], new List<string>());
                        vloggerFollowing.Add(commands[0], new List<string>());
                        vloggers.Add(commands[0], new List<int> { 0,0});
                    }
                }
                else if (commands[1] == "followed")
                {
                    if (commands[0] != commands[2])
                    {
                        if (vloggerFollowers.ContainsKey(commands[0]) && vloggerFollowers.ContainsKey(commands[2]))
                        {
                            if (!vloggerFollowing[commands[2]].Contains(commands[0]))
                            {
                                vloggerFollowers[commands[2]].Add(commands[0]);
                                vloggerFollowing[commands[2]].Add(commands[0]);
                                vloggers[commands[2]][0] += 1;
                                vloggers[commands[0]][1] += 1;
                            }
                        }

                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = vloggers.OrderByDescending(s => s.Value[0]).ThenBy(s => s.Value[1]).ToDictionary(s => s.Key, s => s.Value);
            int count = 1;
            foreach (var item in vloggers)
            {
                foreach (var kvp in vloggerFollowers)
                {
                    if (item.Key == kvp.Key)
                    {
                        if (count == 1)
                        {
                            Console.WriteLine($"{count}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");
                            if (kvp.Value.Count > 0)
                            {
                            Console.WriteLine($"*  {string.Join("\n*  ", kvp.Value.OrderBy(s=>s))}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{count}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");
                        }
                        count++;
                    }
                }
            }
        }
    }
}
