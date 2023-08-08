using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class CategoriesByProductsCountOutput
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal ProductsAveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal ProductsRevenue { get; set; }
    }
}
