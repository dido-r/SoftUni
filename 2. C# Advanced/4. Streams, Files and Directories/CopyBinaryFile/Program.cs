using System;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe_copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream read = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream write = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new Byte[1024];
                    int bytesRead = 0;

                    while ((bytesRead = read.Read(buffer, 0, 1024)) > 0)
                    {
                        write.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
