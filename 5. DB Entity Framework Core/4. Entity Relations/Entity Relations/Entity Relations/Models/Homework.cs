using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{   
    [Table("HomeworkSubmissions")]
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }

        [ForeignKey(nameof(Course))]
        [InverseProperty("HomeworkSubmissions")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey(nameof(Student))]
        [InverseProperty("HomeworkSubmissions")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
    }

    public enum ContentType
    {
        Application, 
        Pdf, 
        Zip
    }
}
