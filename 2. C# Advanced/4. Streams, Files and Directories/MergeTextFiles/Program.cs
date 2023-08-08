using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            string firstInputFilePath = @"..\..\..\input1.txt";
            string secondInputFilePath = @"..\..\..\input2.txt";
            string outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                string[] file1 = File.ReadAllLines(@"..\..\..\input1.txt");
                string[] file2 = File.ReadAllLines(@"..\..\..\input2.txt");
                int maxLenght = Math.Max(file1.Length, file2.Length);

                for (int i = 0; i < maxLenght; i++)
                {
                    if (i >= file1.Length)
                    {
                        write.WriteLine(file2[i]);
                    }
                    else if (i >= file2.Length)
                    {
                        write.WriteLine(file1[i]);
                    }
                    else
                    {
                        write.WriteLine(file1[i]);
                        write.WriteLine(file2[i]);
                    }
                }
            }
        }
    }
}
