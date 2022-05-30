using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string[] contest = Console.ReadLine().Split(":");
            while (contest[0] != "end of contests")
            {
                contests.Add(contest[0], contest[1]);
                contest = Console.ReadLine().Split(":");
            }
            string[] user = Console.ReadLine().Split("=>");
            while (user[0] != "end of submissions")
            {
                string contestName = user[0];
                string contestPassword = user[1];
                string userName = user[2];
                int points = int.Parse(user[3]);
                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName] == contestPassword)
                    {
                        if (users.ContainsKey(userName))
                        {
                            if (users[userName].ContainsKey(contestName))
                            {
                                if (users[userName][contestName] < points)
                                {
                                    users[userName][contestName] = points;
                                }
                            }
                            else
                            {
                                users[userName].Add(contestName, points);
                            }
                        }
                        else
                        {
                            users.Add(user[2], new Dictionary<string, int> { { user[0], points } });
                        }
                    }
                }
                user = Console.ReadLine().Split("=>");
            }
            string userMax = "";
            int userMaxPoints = int.MinValue;
            foreach (var item in users)
            {
                int currentPoints = 0;
                foreach (var points in item.Value)
                {
                    currentPoints += points.Value;
                    if (currentPoints > userMaxPoints)
                    {
                        userMax = item.Key;
                        userMaxPoints = currentPoints;
                    }
                }
            }
            Console.WriteLine($"Best candidate is {userMax} with total {userMaxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in users)
            {
                Console.WriteLine(item.Key);
                foreach (var points in item.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {points.Key} -> {points.Value}");
                }
            }
        }
    }
}
