using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                using (StreamReader read = new StreamReader(inputFilePath))
                {
                    var line = read.ReadLine();
                    int index = 1;

                    while (line != null)
                    {
                        write.WriteLine($"{index++}. {line}");
                        line = read.ReadLine();
                    }
                }
            }
        }
    }

}
