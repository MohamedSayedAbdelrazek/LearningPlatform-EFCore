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

            #region Seed Student Data
            if (!await context.Students.AnyAsync())
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
            #endregion

            #region Seed Enrollments
            if (!await context.Set<StudentCourse>().AnyAsync())
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
            #endregion

            #region Part03 => Create
            ////Add instructor 
            //var instructor = new Instructor
            //{
            //    FullName = "Adham Atef",
            //    Email = "Adham@email.com",
            //    JoinDate = DateTime.Now
            //};
            //await context.Set<Instructor>().AddAsync(instructor);
            //await context.SaveChangesAsync();
            //Console.WriteLine($"The generated Instructor Id is : {instructor.Id}");

            ////Add course
            //var course = new Course
            //{
            //    InstructorId = instructor.Id,
            //    CategoryId = 1,
            //    Title = "Programming",
            //    Price = 6000,
            //    IsPublished = true,
            //    PublishedDate = DateTime.Now
            //};

            //if (!await context.Set<Instructor>().AnyAsync(I => I.Id == instructor.Id))
            //    Console.WriteLine("Instructor not found");
            //else if (!await context.Set<Category>().AnyAsync(C => C.Id == 1))
            //    Console.WriteLine("Category with Id 1 is not exist");
            //else
            //{
            //    await context.Set<Course>().AddAsync(course);
            //    await context.SaveChangesAsync();
            //}

            ////Add several students
            //var studentss = new List<Student>()
            //{
            //    new Student()
            //    {
            //        Name = "Mo",
            //        Email="mo@gmail.com",
            //        DOB=new DateTime(2005,12,13)
            //    },
            //    new Student()
            //    {
            //        Name = "Ahmed",
            //        Email="ahmed@gmail.com",
            //        DOB=new DateTime(2000,08,20)
            //    },
            //    new Student()
            //    {
            //        Name = "Abdo",
            //        Email="abdo@gmail.com",
            //        DOB = new DateTime(2000,09,12)
            //    }
            //};
            //await context.Students.AddRangeAsync(studentss);
            //await context.SaveChangesAsync();

            //for (int i = 0; i < 3; i++)
            //    Console.WriteLine($"Generated Id for Student {i + 1} => {studentss[i].Id}");

            ////Enroll a student
            //var student = studentss[0];
            //bool studentExists = await context.Set<Student>().AnyAsync(s => s.Id == student.Id);
            //var existingCourse = await context.Set<Course>().FirstOrDefaultAsync(c => c.Id == course.Id);

            //if (!studentExists)
            //{
            //    Console.WriteLine("Student not found");
            //}
            //else if (existingCourse == null)
            //{
            //    Console.WriteLine("Course not found");
            //}
            //else if (!existingCourse.IsPublished)
            //{
            //    Console.WriteLine("Sorry, the course is not published");
            //}
            //else if (await context.Set<StudentCourse>()
            //            .AnyAsync(SC => SC.StudentId == student.Id && SC.CourseId == course.Id))
            //    Console.WriteLine("Sorry, The student is already enrolled in a course");
            //else
            //{
            //    var enroll = new StudentCourse()
            //    {
            //        StudentId = student.Id,
            //        CourseId = course.Id,
            //        EnrollmentDate = DateTime.UtcNow,
            //        ProgressPercentage = 0,
            //        Status = Status.Active,
            //        FinalGrade = null
            //    };

            //    await context.Set<StudentCourse>().AddAsync(enroll);
            //    context.SaveChanges();
            //    Console.WriteLine("Student enrolled successfully!");

            //} 
            #endregion

            #region Part03 => Read
            //find a course
            //var course = await context.Courses.FindAsync(1);
            //var course02 = await context.Courses.FirstOrDefaultAsync(C => C.Title == "Programming");
            //if (course is null)
            //    Console.WriteLine("Course01 is null");
            //if (course02 is null)
            //    Console.WriteLine("Course02 is null");
            
            ////filter courses
            //var courses = await context.Courses.Where(C => C.Price >= 2000 && C.Price <= 5000)
            //    .OrderByDescending(C => C.Price)
            //    .Select(C => new {C.Title,C.Level,C.Price})
            //    .ToListAsync();

            //foreach (var c in courses)
            //{
            //    Console.WriteLine($"{c.Title} | {c.Level} | {c.Price}");
            //}

            ////subcategoris, topLevel Categories
            //var subCategories = await context.Set<Category>()
            //    .Where(C => C.ParentId== 1)
            //    .ToListAsync();

            //foreach (var category in subCategories)
            //{
            //    Console.WriteLine(category.Name);
            //}

            //var topLevelCategories = await context.Set<Category>()
            //    .Where(c => c.ParentId == null)
            //    .ToListAsync();

            //foreach (var category in topLevelCategories)
            //{
            //    Console.WriteLine(category.Name);
            //}

            ////Course roster
            //var studentIds = await context.Set<StudentCourse>()
            //    .Where(SC => SC.CourseId == 1)
            //    .Select(SC => SC.StudentId)
            //    .ToListAsync();

            //var studentNames = await context.Set<Student>()
            //    .Where(S => studentIds.Contains(S.Id))
            //    .ToListAsync();

            //Console.WriteLine($"Enrolled Students: {studentNames.Count}");

            //foreach (var student in studentNames)
            //{
            //    Console.WriteLine(student.Name);
            //}
            #endregion

        }
    }
}
