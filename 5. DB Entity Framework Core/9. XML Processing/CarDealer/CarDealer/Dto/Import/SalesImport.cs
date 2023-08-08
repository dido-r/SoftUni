using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Sale")]
    public class SalesImport
    {
        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
