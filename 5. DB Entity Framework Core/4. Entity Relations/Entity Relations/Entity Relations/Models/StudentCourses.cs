using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        [InverseProperty("CourseEnrollments")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        [InverseProperty("StudentsEnrolled")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
