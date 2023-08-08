using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\TestFolder";
            string outputFilePath = @"..\..\..\output.txt";

            GetFolderSize(folderPath, outputFilePath);
        }
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles("", SearchOption.AllDirectories);
            double size = 0;

            foreach (var file in files)
            {
                size += file.Length;
            }
            size /= 1024;
            File.WriteAllText(outputFilePath, size.ToString() + " KB");
        }
    }
}
