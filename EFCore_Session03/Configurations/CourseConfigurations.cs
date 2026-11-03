using EFCore_Session03.Enums;
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
    internal class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(C => C.Instructor)
                .WithMany(I => I.Courses)
                .HasForeignKey(C => C.InstructorId);

            builder.HasOne(C => C.Category)
                .WithMany(Ca => Ca.Courses)
                .HasForeignKey(C => C.CategoryId);


            builder.Property(nameof(Course.Price))
                 .HasColumnType("decimal(16,2)");

            builder.HasData(
                new
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# from scratch",
                    Price = 150m,
                    Level = Level.Beginner,
                    IsPublished = true,
                    PublishedDate = (DateTime?)new DateTime(2026, 1, 10),
                    InstructorId = 1,
                    CategoryId = 2
                },
                new
                {
                    Id = 2,
                    Title = "ASP.NET Core Web API",
                    Description = "Building REST APIs",
                    Price = 300m,
                    Level = Level.Intermediate,
                    IsPublished = true,
                    PublishedDate = (DateTime?)new DateTime(2026, 2, 15),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new
                {
                    Id = 3,
                    Title = " Entity Framework Core",
                    Description = "Advanced EF Core concepts",
                    Price = 400m,
                    Level = Level.Advanced,
                    IsPublished = true,
                    PublishedDate = (DateTime?)new DateTime(2026, 3, 10),
                    InstructorId = 2,
                    CategoryId = 3
                },
                new
                {
                    Id = 4,
                    Title = "HTML and CSS",
                    Description = "Frontend fundamentals",
                    Price = 100m,
                    Level = Level.Beginner,
                    IsPublished = true,
                    PublishedDate = (DateTime?)new DateTime(2026, 4, 5),
                    InstructorId = 2,
                    CategoryId = 4
                },
                new
                {
                    Id = 5,
                    Title = "JavaScript ",
                    Description = "Modern JavaScript",
                    Price = 250m,
                    Level = Level.Intermediate,
                    IsPublished = false,
                    PublishedDate = (DateTime?)null,
                    InstructorId = 3,
                    CategoryId = 4
                },
                new
                {
                    Id = 6,
                    Title = "Data Science ",
                    Description = "Introduction to Data Science",
                    Price = 350m,
                    Level = Level.Advanced,
                    IsPublished = true,
                    PublishedDate = (DateTime?)new DateTime(2026, 5, 10),
                    InstructorId = 3,
                    CategoryId = 5
                }
            );

        }
    }
}
