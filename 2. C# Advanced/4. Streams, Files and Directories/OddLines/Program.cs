using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                using (StreamReader read = new StreamReader(inputFilePath))
                {
                    while (read.ReadLine() != null)
                    {
                        write.WriteLine(read.ReadLine());
                    }
                }
            }
        }
    }

}
