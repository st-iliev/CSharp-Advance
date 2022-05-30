namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader read = new StreamReader(inputFilePath);
            StringBuilder text = new StringBuilder();
            string line = read.ReadLine();
            int counter = 0;
            char[] symbols = new char[] { '-', ',', '.', '!', '?' };
            while (line!=null)
            {
                line = read.ReadLine();
                if (counter % 2 == 0)
                {
                    foreach (var item in symbols)
                    {
                        line = line.Replace(item, '@');
                    }
                    line = string.Join(" ", line.Split().Reverse());
                    text.AppendLine(line);
                }
                counter++;
            }
            return text.ToString().TrimEnd();
        }
       
    }

}

