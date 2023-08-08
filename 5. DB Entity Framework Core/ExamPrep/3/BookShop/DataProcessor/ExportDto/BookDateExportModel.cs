using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BookDateExportModel
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlAttribute]
        public int Pages { get; set; }

        [XmlElement]
        public string Date { get; set; }
    }
}
