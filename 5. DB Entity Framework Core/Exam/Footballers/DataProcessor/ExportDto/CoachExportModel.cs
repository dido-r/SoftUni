using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachExportModel
    {
        [XmlAttribute]
        public int FootballersCount { get; set; }

        [XmlElement]
        public string CoachName { get; set; }

        [XmlArray]
        public FootballerXmlExportModel[] Footballers { get; set; }
    }
}
