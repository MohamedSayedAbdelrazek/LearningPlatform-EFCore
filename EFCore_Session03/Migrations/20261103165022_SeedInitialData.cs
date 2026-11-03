using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_Session03.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Programming courses", "Programming", null },
                    { 5, null, "Data Science", null }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinDate" },
                values: new object[,]
                {
                    { 1, "Backend Instructor", "ahmed@gmail.com", "Ahmed Mohamed", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Full Stack Instructor", "sara.@gmail.com", "Sara Mohamed", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Software Instructor", "mohamed.@gmail.com", "Mohamed Sayed", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, null, "Backend", 1 },
                    { 4, null, "Frontend", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[] { 6, 5, "Introduction to Data Science", 3, true, 2, 350m, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science " });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[] { 3, null, "ASP.NET", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Learn C# from scratch", 1, true, 0, 150m, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" },
                    { 4, 4, "Frontend fundamentals", 2, true, 0, 100m, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML and CSS" },
                    { 5, 4, "Modern JavaScript", 3, false, 1, 250m, null, "JavaScript " },
                    { 2, 3, "Building REST APIs", 1, true, 1, 300m, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API" },
                    { 3, 3, "Advanced EF Core concepts", 2, true, 2, 400m, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), " Entity Framework Core" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
