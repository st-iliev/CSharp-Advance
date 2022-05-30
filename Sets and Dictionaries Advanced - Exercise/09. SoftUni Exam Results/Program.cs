using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> languages = new Dictionary<string, int>();
            string[] userResult = Console.ReadLine().Split("-");
            while (userResult[0]!="exam finished")
            {
                string userName = userResult[0];
                string language = userResult[1];            
                if (language == "banned")
                {
                    users.Remove(userName);
                }
                else
                {
                    int points = int.Parse(userResult[2]);
                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, new Dictionary<string, int> { { language, points } });
                        if (!languages.ContainsKey(language))
                        {
                            languages.Add(language, 1);
                        }
                        else
                        {
                            languages[language] += 1;
                        }
                    }
                    else
                    {
                        if (!languages.ContainsKey(language))
                        {
                            languages.Add(language, 1);
                        }
                        else
                        {
                            languages[language] += 1;
                        }
                        if (users[userName].ContainsKey(language))
                        {
                            if (users[userName][language] < points)
                            {
                                users[userName][language] = points;
                            }
                        }
                        else
                        {
                            users[userName].Add(language, points);
                        }
                    }
                }
               
                userResult = Console.ReadLine().Split("-");
            }
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var item in users)
            {
                foreach (var kvp in item.Value)
                {
                    results.Add(item.Key, kvp.Value);
                }
            }
            Console.WriteLine($"Results:");
            results = results.OrderByDescending(s => s.Value).ThenBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
            foreach (var item in results)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine($"Submissions:");
            languages = languages.OrderByDescending(s => s.Value).ThenBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
            foreach (var item in languages)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
