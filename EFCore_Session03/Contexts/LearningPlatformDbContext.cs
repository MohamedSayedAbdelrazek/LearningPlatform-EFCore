using EFCore_Session03.Configurations;
using EFCore_Session03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Session03.Contexts
{
    internal class LearningPlatformDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public  DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=LearningPlatform;Trusted_Connection=True; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new CourseConfigurations());
            modelBuilder.ApplyConfiguration(new StudentCourseConfigurations());
            modelBuilder.ApplyConfiguration(new InstructorConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());


        }
    }
}
