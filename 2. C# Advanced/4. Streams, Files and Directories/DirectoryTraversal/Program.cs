using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {

            string inputFolderPath = Console.ReadLine();
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";

            string textContent = TraverseDirectory(inputFolderPath);
            WriteReportToDesktop(textContent, outputFilePath);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string textContent = string.Empty;
            textContent = inputFolderPath;
            return textContent;
        }

        public static void WriteReportToDesktop(string textContent, string outputFilePath)
        {
            DirectoryInfo dir = new DirectoryInfo(textContent);
            FileInfo[] files = dir.GetFiles("", SearchOption.TopDirectoryOnly);
            Dictionary<string, Dictionary<string, double>> list = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                if (!list.ContainsKey(file.Extension))
                {
                    list.Add(file.Extension, new Dictionary<string, double>());
                }
                list[file.Extension].Add(file.Name, file.Length);
            }

            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                foreach (var item in list.OrderByDescending(x => x.Value.Keys.Count).ThenBy(name => name.Key))
                {
                    write.WriteLine($"{item.Key}");

                    foreach (var file in item.Value.OrderBy(size => size.Value))
                    {
                        write.WriteLine($"--{file.Key} - {file.Value} kb");
                    }
                }
            }
        }
    }
}
