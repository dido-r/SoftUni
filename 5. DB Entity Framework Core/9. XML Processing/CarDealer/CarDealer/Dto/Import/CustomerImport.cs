using System;
using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Customer")]
    public class CustomerImport
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
