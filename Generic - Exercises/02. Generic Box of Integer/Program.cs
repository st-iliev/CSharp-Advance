using System;

namespace GenericExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lineOfText = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineOfText; i++)
            {
                int line = int.Parse(Console.ReadLine());
                var box = new Box<int>(line);
                Console.WriteLine(box);
            }
        }
    }
}
