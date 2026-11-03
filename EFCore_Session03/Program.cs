using EFCore_Session03.Contexts;
using EFCore_Session03.Enums;
using EFCore_Session03.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Session03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new LearningPlatformDbContext();
            
            //Seed Student Data
            if(!await context.Students.AnyAsync())
            {
                await context.Students.AddRangeAsync(
                         new Student
                         {
                             Name = "Ali Ahmed",
                             Email = "ali@gmail.com",
                             DOB = new DateTime(2002, 5, 10)
                         },
                        new Student
                        {
                            Name = "Sara Mohamed",
                            Email = "sara@gmail.com",
                            DOB = new DateTime(2001, 8, 15)
                        },
                        new Student
                        {
                            Name = "Omar Ali",
                            Email = "omar@gmail.com",
                            DOB = new DateTime(2003, 3, 20)
                        },
                        new Student
                        {
                            Name = "Mona Hassan",
                            Email = "mona@gmail.com",
                            DOB = new DateTime(2002, 11, 5)
                        },
                        new Student
                        {
                            Name = "Nour Khaled",
                            Email = "nour@gmail.com",
                            DOB = new DateTime(2000, 7, 12)
                        }

                    );
                await context.SaveChangesAsync();
            }

            //Seed Enrollments
            if(!await context.Set<StudentCourse>().AnyAsync())
            {
                var emails = new[]
                    {
                        "ali@gmail.com",
                        "sara@gmail.com",
                        "omar@gmail.com",
                        "mona@gmail.com",
                        "nour@gmail.com"
                    };

                var students = await context.Students
                    .Where(S => emails.Contains(S.Email))
                    .ToDictionaryAsync(S => S.Email, S => S.Id);

                var enrollmentDate = DateTime.Now;

                await context.Set<StudentCourse>().AddRangeAsync(
                         new StudentCourse
                         {
                             StudentId = students["ali@gmail.com"],
                             CourseId = 1,
                             EnrollmentDate = enrollmentDate,
                             ProgressPercentage = 0,
                             Status = Status.Active,
                             FinalGrade = null
                         },
                        new StudentCourse
                        {
                            StudentId = students["ali@gmail.com"],
                            CourseId = 2,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 50,
                            Status = Status.Active,
                            FinalGrade = null
                        },
                        new StudentCourse
                        {
                            StudentId = students["sara@gmail.com"],
                            CourseId = 1,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 100,
                            Status = Status.Completed,
                            FinalGrade = 95m
                        },
                        new StudentCourse
                        {
                            StudentId = students["sara@gmail.com"],
                            CourseId = 3,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 100,
                            Status = Status.Completed,
                            FinalGrade = 88m
                        },
                        new StudentCourse
                        {
                            StudentId = students["omar@gmail.com"],
                            CourseId = 2,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 35,
                            Status = Status.Dropped,
                            FinalGrade = null
                        },
                        new StudentCourse
                        {
                            StudentId = students["omar@gmail.com"],
                            CourseId = 4,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 10,
                            Status = Status.Active,
                            FinalGrade = null
                        },
                        new StudentCourse
                        {
                            StudentId = students["mona@gmail.com"],
                            CourseId = 3,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 70,
                            Status = Status.Active,
                            FinalGrade = null
                        },
                        new StudentCourse
                        {
                            StudentId = students["nour@gmail.com"],
                            CourseId = 6,
                            EnrollmentDate = enrollmentDate,
                            ProgressPercentage = 100,
                            Status = Status.Completed,
                            FinalGrade = 91m
                        }

                    );
                await context.SaveChangesAsync();

            }


        }
    }
}
