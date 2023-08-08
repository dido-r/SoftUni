using System;
using System.Linq;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                string[] line = File.ReadAllLines(@"..\..\..\text.txt");
                int count = 1;

                for (int i = 0; i < line.Length; i++)
                {
                    write.WriteLine($"Line {count++}: {line[i]} ({line[i].Count(x => char.IsLetter(x))})({line[i].Count(y => char.IsPunctuation(y))})");
                }
            }
        }
    }
}
