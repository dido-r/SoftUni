using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamWriter write = new StreamWriter(outputFilePath))
            {
                Dictionary<string, int> list = new Dictionary<string, int>();

                using (StreamReader word = new StreamReader(wordsFilePath))
                {
                    string[] words = word.ReadLine().Split();

                    foreach (var item in words)
                    {
                        int count = 0;
                        using (StreamReader text = new StreamReader(textFilePath))
                        {
                            string[] block = text.ReadToEnd().Split();

                            foreach (var w in block)
                            {
                                if (item.ToLower() == w.Trim(new[] { '.', '!', '?', '-', ',', '"' }).ToLower())
                                {
                                    count++;
                                }
                            }
                        }
                        list.Add(item, count);
                    }
                }
                foreach (var item in list.OrderByDescending(x => x.Value))
                {
                    write.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }

}
