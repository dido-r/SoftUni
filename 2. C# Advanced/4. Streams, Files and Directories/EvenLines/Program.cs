using System;
using System.IO;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string result = string.Empty;

            using (StreamReader read = new StreamReader(inputFilePath))
            {
                var line = read.ReadLine();
                int index = 0;

                while (line != null)
                {
                    if (index++ % 2 == 0)
                    {
                        line = line.Replace('-', '@');
                        line = line.Replace(',', '@');
                        line = line.Replace('.', '@');
                        line = line.Replace('!', '@');
                        line = line.Replace('?', '@');
                        string[] output = line.Split();

                        for (int i = output.Length - 1; i >= 0; i--)
                        {
                            result += output[i] + " ";
                        }
                        result += $"\n";
                    }
                    line = read.ReadLine();
                }
            }
            return result;
        }
    }
}
