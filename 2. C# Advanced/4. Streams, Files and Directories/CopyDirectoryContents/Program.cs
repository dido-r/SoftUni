using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main(string[] args)
        {

            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo dir = new DirectoryInfo(inputPath);

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);

            FileInfo[] files = dir.GetFiles();

            foreach (var file in files)
            {
                string finalPath = Path.Combine(outputPath, file.Name);
                file.CopyTo(finalPath);
            }
        }
    }
}
