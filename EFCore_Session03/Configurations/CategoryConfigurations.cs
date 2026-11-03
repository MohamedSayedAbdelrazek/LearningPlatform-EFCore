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
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(C => C.Childs)
                .WithOne(C => C.Parent)
                .HasForeignKey(C => C.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(nameof(Category.Name))
                .HasMaxLength(100);
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming courses",
                    ParentId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Backend",
                    ParentId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "ASP.NET",
                    ParentId = 2
                },
                new Category
                {
                    Id = 4,
                    Name = "Frontend",
                    ParentId = 1
                },
                new Category
                {
                    Id = 5,
                    Name = "Data Science",
                    ParentId = null
                }
            );
        }
    }
}
