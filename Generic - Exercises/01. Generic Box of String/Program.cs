using System;

namespace Generic_Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lineOfText = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineOfText; i++)
            {
                string line = Console.ReadLine();
                var box = new Box<string>(line);
                Console.WriteLine(box);
            }
        }
    }
}
