using System.Collections.Generic;

namespace BookShop.DataProcessor.ExportDto
{
    public class AuthorExportModel
    {
        public string AuthorName { get; set; }

        public List<BookExportModel> Books { get; set; }
    }
}
