using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            var png = Encoding.UTF8.GetBytes(binaryFilePath);
            var text = File.ReadAllLines(bytesFilePath);
            byte[] bytes = new byte[1024];

            for (int i = 0; i < text.Length; i++)
            {
                bytes[i] = byte.Parse(text[i]);
            }

            File.WriteAllBytes(outputPath, bytes);
            File.WriteAllBytes(outputPath, png);
        }
    }
}

