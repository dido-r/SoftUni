﻿using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Supplier")]
    public class SupplierImport
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]

        public bool IsImporter { get; set; }
    }
}
