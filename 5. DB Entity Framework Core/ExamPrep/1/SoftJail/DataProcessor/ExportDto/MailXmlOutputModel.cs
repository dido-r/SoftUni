using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class MailXmlOutputModel
    {
        [XmlElement]
        public string Description { get; set; }
    }
}
