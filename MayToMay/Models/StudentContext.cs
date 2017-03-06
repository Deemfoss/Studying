using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MayToMay.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
    public class CourseDBinitializer : DropCreateDatabaseAlways<StudentContext>
    {

        protected override void Seed(StudentContext context)
        {
            Student s1 = new Student { Id = 1, Name = "Артем", Surname = "Дугов" };
            Student s2 = new Student { Id = 2, Name = "Андрей", Surname ="Жборов" };
            Student s3 = new Student { Id = 3, Name = "Коля", Surname = "Дваров" };
            Student s4 = new Student { Id = 4, Name = "Иван", Surname = "Иванов" };
            base.Seed(context);

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);

            Course C1 = new Course
            {
                id = 1,
                Name = "Операционные системы",
                Students = new List<Student> { s1, s2, s3 }
            };


            Course C2 = new Course
            {
                id = 2,
                Name = "Алгоритмы и структуры данных",
                Students = new List<Student> {  s2, s4 }
            };


            Course C3= new Course
            {
                id = 3,
                Name = "Основы html и css",
                Students = new List<Student> { s3, s4, s1 } 
            };
            context.Courses.Add(C1);
            context.Courses.Add(C2);
            context.Courses.Add(C3);

            context.SaveChanges(); 
        }


       

    }

    }
