using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Advanced_Exam___23_October_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> vowels = new List<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>();
            words.Add("pear", new List<char>(new char[] { 'p', 'e', 'a', 'r' }));
            words.Add("flour", new List<char>(new char[] { 'f', 'l', 'o', 'u', 'r' }));
            words.Add("pork", new List<char>(new char[] { 'p', 'o', 'r', 'k' }));
            words.Add("olive", new List<char>(new char[] { 'o', 'l', 'i', 'v','e' }));
            while (consonants.Count > 0)
            {
                char currentVowel = vowels[0];
                vowels.RemoveAt(0);
                vowels.Add(currentVowel);
                char currentConsonant = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Value.Contains(currentVowel))
                    {
                        int index = word.Value.IndexOf(currentVowel);
                        word.Value.RemoveAt(index);
                    }
                    if (word.Value.Contains(currentConsonant))
                    {
                        int index = word.Value.IndexOf(currentConsonant);
                        word.Value.RemoveAt(index);
                    }
                }
            }
            Console.WriteLine($"Words found: { words.Where(s=>s.Value.Count ==0).Count()}");
            foreach (var word in words)
            {
                if (word.Value.Count == 0)
                {
                    Console.WriteLine(word.Key);
                }
            }
        }
    }
}
