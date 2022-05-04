using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int result = DateModifier.Calculated(firstDate, secondDate);
            Console.WriteLine(result);
        }
    }
}
