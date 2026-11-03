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

            #region Part03 => Update
            ////change course price
            //var course = await context.Courses.FindAsync(1);
            //if(course is not null)
            //    course.Price = 10000;
            //await context.SaveChangesAsync();

            ////update progress
            //int courseId = 1;
            //int studentId = 2;
            //int newProgress = 100;

            //if (newProgress < 0 || newProgress > 100)
            //{
            //    Console.WriteLine("Progress must be between 0 and 100");
            //}
            //else
            //{
            //    // Find enrollment
            //    var enrollment = await context.Set<StudentCourse>()
            //        .FindAsync(courseId, studentId);

            //    if (enrollment is null)
            //    {
            //        Console.WriteLine("Enrollment not found");
            //    }
            //    else
            //    {
            //        enrollment.ProgressPercentage = newProgress;

            //        if (newProgress == 100)
            //        {
            //            enrollment.Status = Status.Completed;
            //        }

            //        await context.SaveChangesAsync();

            //        Console.WriteLine("Progress updated successfully");
            //    }
            //}

            ////Publish a course
            //int courseIdToPublish = 5;

            //var course2 = await context.Set<Course>()
            //    .FindAsync(courseIdToPublish);

            //if (course2 is null)
            //{
            //    Console.WriteLine("Course not found");
            //}
            //else if (course2.IsPublished)
            //{
            //    Console.WriteLine("Course is already published");
            //}
            //else
            //{
            //    course2.IsPublished = true;
            //    course2.PublishedDate = DateTime.Now;

            //    await context.SaveChangesAsync();

            //    Console.WriteLine("Course published successfully!");
            //}
            #endregion

            #region Part03 => Delete

            ////1.
            //int courseId = 1;
            //int studentId = 2;
            //var enroll = await context.Set<StudentCourse>()
            //    .FindAsync(courseId,studentId);
            //if (enroll is not null)
            //{
            //    context.Set<StudentCourse>().Remove(enroll);
            //    await context.SaveChangesAsync();

            //    Console.WriteLine("Student unenrolled successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Enrollment not found");
            //}

            ////2.
            //try
            //{
            //    var category = await context.Set<Category>()
            //        .FirstOrDefaultAsync(C => C.Childs.Any());
            //    if (category is not null)
            //    {
            //        context.Set<Category>().Remove(category);

            //        await context.SaveChangesAsync();
            //    }
            //}
            //catch(DbUpdateException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ////safe version
            //int categoryId = 1;

            //bool hasChildren = await context.Set<Category>()
            //    .AnyAsync(c => c.ParentId == categoryId);

            //if (hasChildren)
            //{
            //    Console.WriteLine("Cannot delete category with children");
            //}
            //else
            //{
            //    var category = await context.Set<Category>()
            //        .FindAsync(categoryId);

            //    if (category is not null)
            //    {
            //        context.Set<Category>().Remove(category);

            //        await context.SaveChangesAsync();

            //        Console.WriteLine("Category deleted successfully");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Category not found");
            //    }
            //}

            ////3.
            //int courseIdToDelete = 1;

            //// Count before deletion
            //int countBefore = await context.Set<StudentCourse>()
            //    .CountAsync(sc => sc.CourseId == courseIdToDelete);

            //Console.WriteLine($"Enrollments before: {countBefore}");

            //var courseToDelete = await context.Set<Course>()
            //    .FindAsync(courseIdToDelete);

            //if (courseToDelete is null)
            //{
            //    Console.WriteLine("Course not found");
            //}
            //else if (countBefore == 0)
            //{
            //    Console.WriteLine("Choose a course that has enrollments");
            //}
            //else
            //{
            //    context.Set<Course>().Remove(courseToDelete);

            //    await context.SaveChangesAsync();

            //    // Enrollments are deleted automatically
            //    // because the Course -> StudentCourse FK
            //    // is configured with Cascade Delete.

            //    int countAfter = await context.Set<StudentCourse>()
            //        .CountAsync(sc => sc.CourseId == courseIdToDelete);

            //    Console.WriteLine($"Enrollments after: {countAfter}");
            //}

            #endregion

        }
    }
}
