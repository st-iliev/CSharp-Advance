using System;
using System.Linq;

namespace IteratorsandComparatorsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = new ListyIterator<string>();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "END")
            {
                if (commands[0] == "Create")
                {
                    listy = new ListyIterator<string>(commands.Skip(1).ToArray());
                }
                else if (commands[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (commands[0] == "Print")
                {
                    listy.Print();
                }
                else if (commands[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
            commands = Console.ReadLine().Split();
            }
        }
    }
}

