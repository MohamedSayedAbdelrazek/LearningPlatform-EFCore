using EFCore_Session03.Enums;
namespace EFCore_Session03.Models
{
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercentage { get; set; }
        public Status Status { get; set; }
        public decimal? FinalGrade { get; set; }
    }
}
