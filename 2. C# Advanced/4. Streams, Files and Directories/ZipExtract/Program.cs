using System;
using System.Linq;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string zipArchiveFilePath = @"..\..\..\archive.zip";
            string fileName = "extracted.png";
            string outputFilePath = @"..\..\..\";

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (FileStream stream = new FileStream(zipArchiveFilePath, FileMode.Create))
            {
                using (ZipArchive zipped = new ZipArchive(stream, ZipArchiveMode.Create))
                {
                    zipped.CreateEntryFromFile(inputFilePath, "copyMe.png");
                }
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (var archive = new ZipArchive(File.Open(zipArchiveFilePath, FileMode.Open, FileAccess.ReadWrite), ZipArchiveMode.Update))
            {
                var entries = archive.Entries.ToArray();

                foreach (var entry in entries)
                {
                    var newEntry = archive.CreateEntry(fileName);
                    using (var a = entry.Open())
                    using (var b = newEntry.Open())
                        a.CopyTo(b);
                    entry.Delete();
                }
            }
            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath);
        }
    }
}
