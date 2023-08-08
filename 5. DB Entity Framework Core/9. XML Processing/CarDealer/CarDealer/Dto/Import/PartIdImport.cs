using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("partId")]
    public class PartIdImport
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
