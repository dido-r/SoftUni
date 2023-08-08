using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Resource))]
        [InverseProperty("Resources")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
    public enum ResourceType
    { 
        Video, 
        Presentation, 
        Document, 
        Other 
    }
}
