﻿using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class CastExportModel
    {
        [XmlAttribute]
        public string FullName { get; set; }

        [XmlAttribute]
        public string MainCharacter { get; set; }
    }
}
