using System;
using System.Collections.Generic;
using System.Linq;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool isBalanced = true;
            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    parentheses.Push(item);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        char lastParenthes = parentheses.Peek();
                        if (item == '}' && lastParenthes == '{')
                        {
                            parentheses.Pop();
                            continue;
                        }
                        else if (item == ']' && lastParenthes == '[')
                        {
                            parentheses.Pop();
                            continue;
                        }
                        else if (item == ')' && lastParenthes == '(')
                        {
                            parentheses.Pop();
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
