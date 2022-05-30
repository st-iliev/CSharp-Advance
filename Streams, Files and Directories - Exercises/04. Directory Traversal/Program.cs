namespace DirectoryTraversal
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();
            foreach (var item in files)
            {
                string fileName = Path.GetFileName(item);
                string extansion = Path.GetExtension(item);
                double size = new FileInfo(item).Length / 1024.0;
                if (!filesInfo.ContainsKey(extansion))
                {
                    filesInfo.Add(extansion, new Dictionary<string, double>());
                }
                filesInfo[extansion].Add(fileName, size);

            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in filesInfo.OrderByDescending(s=>s.Value.Count))
            {
                sb.AppendLine(item.Key);
                foreach (var kvp in item.Value)
                {
                    sb.AppendLine($"--{kvp.Key} - {kvp.Value}kb");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(path, textContent);
        }

    }
}
