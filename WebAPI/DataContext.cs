using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebAPI.Models;

namespace WebAPI
{
    public class DataContext : DbContext
    {
        public DbSet<TeacherModel> teachers { get; set; }
        public DbSet<LessonModel> lessons { get; set; }
        public DbSet<StudentModel> students { get; set; }
        public DbSet<CountyModel> counties { get; set; }
        private readonly IConfiguration _configuration;

        readonly string connectionString;
        // Reaseon: Properties need to make datebase, but we never use them in code.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable. 
        public DataContext(IConfiguration configuration)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _configuration = configuration;
#if DEBUG
#pragma warning disable CS8601 // Possible null reference assignment.
            connectionString = _configuration.GetConnectionString("LocalDB");
#pragma warning restore CS8601 // Possible null reference assignment.
#else
#pragma warning disable CS8601 // Possible null reference assignment.
            connectionString = _configuration.GetConnectionString("MyAspDB");
#pragma warning restore CS8601 // Possible null reference assignment.
#endif
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // -------------- Seed Start -------------- //
            modelBuilder.Entity<TeacherModel>().HasData(
                   new TeacherModel() { id = 1, name = "Kis Béla", email = "bela@gmail.com", phoneNumber = "06706666969" },
                   new TeacherModel() { id = 2, name = "Nagy Anna", email = "anna@gmail.com", phoneNumber = "06304201234" }
                );


            modelBuilder.Entity<StudentModel>().HasData(
                    new StudentModel() { id = 1, name = "Magyar Patrik", email = "patrik@gmail.com", phoneNumber = "06201234567" },
                    new StudentModel() { id = 2, name = "Novák Zsombor", email = "zsombi@gmail.com", phoneNumber = "06301234567" },
                    new StudentModel() { id = 3, name = "Gipsz Jakab", email = "jakab@gmail.com", phoneNumber = "06701234567" }
                );
            modelBuilder.Entity<CountyModel>().HasData(
                new CountyModel() { id = 1, name = "Győr-Moson-Sopron"},
                new CountyModel() { id = 2, name = "Pest"}
            );


            modelBuilder.Entity<LessonModel>().HasData(
                    new LessonModel() { id = 1, price = 2000, subject = "matek", grade = "8. osztály", countyId = 1, teacherId = 1, studentId = 1 },
                    new LessonModel() { id = 2, price = 3000, subject = "matek", grade = "9. osztály", countyId = 2, teacherId = 1, studentId = 2 },
                    new LessonModel() { id = 3, price = 3000, subject = "fizika", grade = "12. osztály", countyId = 1, teacherId = 2, studentId = 3 },
                    new LessonModel() { id = 4, price = 5000, subject = "fizika", grade = "egyetem", countyId = 2, teacherId = 2, studentId = 2 },
                    new LessonModel() { id = 5, price = 2000, subject = "tesi", grade = "bármelyik", countyId = 1, teacherId = 2, studentId = 3 }
                );

            // -------------- Seed End -------------- //
        }
    }
}
