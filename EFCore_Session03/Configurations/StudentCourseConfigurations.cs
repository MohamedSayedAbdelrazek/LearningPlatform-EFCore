using EFCore_Session03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session03.Configurations
{
    internal class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new { sc.CourseId, sc.StudentId });

            builder.HasOne(SC => SC.Student)
               .WithMany(S=> S.StudentCourses)
               .HasForeignKey(SC => SC.StudentId);

            builder.HasOne(SC => SC.Course)
                .WithMany(C => C.StudentCourses)
                .HasForeignKey(SC => SC.CourseId);

            builder.Property(nameof(StudentCourse.FinalGrade))
                .HasPrecision(18,2);
        }
    }
}
