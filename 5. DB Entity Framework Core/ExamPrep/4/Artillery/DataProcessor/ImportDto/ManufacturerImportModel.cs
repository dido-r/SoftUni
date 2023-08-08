﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerImportModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string ManufacturerName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Founded { get; set; }
    }
}
