﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerImportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Weapon { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerIdImportModel[] Prisoners { get; set; }
    }
}
