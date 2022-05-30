namespace LineNumbers
{
    using System;
    using System.Text;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(s => char.IsLetter(s));
                int symbolsCount = lines[i].Count(s => char.IsPunctuation(s));
                text.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
            }
            File.WriteAllText(outputFilePath, text.ToString().TrimEnd());
        }
    }
}
