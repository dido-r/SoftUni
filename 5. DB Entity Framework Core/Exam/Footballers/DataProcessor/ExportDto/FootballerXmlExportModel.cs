using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class FootballerXmlExportModel
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Position { get; set; }
    }
}
