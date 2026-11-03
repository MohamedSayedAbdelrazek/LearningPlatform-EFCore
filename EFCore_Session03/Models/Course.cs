using EFCore_Session03.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session03.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Level Level { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }

        //Instructor relationship
        public required int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        // Category relationship
        public required int CategoryId { get; set; }
        public Category Category { get; set; }

        //StudentCourse relationship
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
