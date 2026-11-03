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
    internal class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(nameof(Instructor.FullName))
                .HasMaxLength(100);
            builder.HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@gmail.com",
                    Bio = "Backend Instructor",
                    JoinDate = new DateTime(2025, 1, 10)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.@gmail.com",
                    Bio = "Full Stack Instructor",
                    JoinDate = new DateTime(2025, 2, 15)
                },
                new Instructor
                {
                    Id = 3,
                    FullName = "Mohamed Sayed",
                    Email = "mohamed.@gmail.com",
                    Bio = "Software Instructor",
                    JoinDate = new DateTime(2025, 3, 20)
                }
            );


        }
    }
}
