using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayImportModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{1}[1-9]{1}(:)[0-9]{2}(:)[0-9]{2}$")]
        public string Duration { get; set; }

        [Required]
        [Range(0, 10)]
        public float Rating { get; set; }

        [Required]
        [RegularExpression(@"^(Drama|Comedy|Romance|Musical)$")]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}
