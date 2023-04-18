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
                   new TeacherModel() { id = 1, name = "Kis Béla", price = 2000, subject = "matek;angol;magyar;atomfizika", grade = "8. osztály", countyId = 1, email = "bela@gmail.com", phoneNumber = "06706666969" },
                   new TeacherModel() { id = 2, name = "Nagy Anna", price = 3000, subject = "matek", grade = "9. osztály", countyId = 2, email = "anna@gmail.com", phoneNumber = "06304201234" }
                );


            modelBuilder.Entity<StudentModel>().HasData(
                    new StudentModel() { id = 1, name = "Magyar Patrik", email = "patrik@gmail.com", phoneNumber = "06201234567" },
                    new StudentModel() { id = 2, name = "Novák Zsombor", email = "zsombi@gmail.com", phoneNumber = "06301234567" },
                    new StudentModel() { id = 3, name = "Gipsz Jakab", email = "jakab@gmail.com", phoneNumber = "06701234567" }
                );

            modelBuilder.Entity<CountyModel>().HasData(
                new CountyModel() { id = 1, name = "Bács-Kiskun" },
                new CountyModel() { id = 2, name = "Baranya" },
                new CountyModel() { id = 3, name = "Békés" },
                new CountyModel() { id = 4, name = "Borsod-Abaúj-Zemplén" },
                new CountyModel() { id = 5, name = "Csongrád" },
                new CountyModel() { id = 6, name = "Fejér" },
                new CountyModel() { id = 7, name = "Győr-Moson-Sopron" },
                new CountyModel() { id = 8, name = "Hajdú-Bihar" },
                new CountyModel() { id = 9, name = "Heves" },
                new CountyModel() { id = 10, name = "Jász-Nagykun-Szolnok" },
                new CountyModel() { id = 11, name = "Komárom-Esztergom" },
                new CountyModel() { id = 12, name = "Nógrád" },
                new CountyModel() { id = 13, name = "Pest" },
                new CountyModel() { id = 14, name = "Somogy" },
                new CountyModel() { id = 15, name = "Szabolcs-Szatmár-Bereg" },
                new CountyModel() { id = 16, name = "Tolna" },
                new CountyModel() { id = 17, name = "Vas" },
                new CountyModel() { id = 18, name = "Veszprém" },
                new CountyModel() { id = 19, name = "Zala" }
            );


            modelBuilder.Entity<LessonModel>().HasData(
                    new LessonModel() { id = 1, teacherId = 1, studentId = 1, date = DateTime.Now.AddDays(-30).AddMinutes(234)},
                    new LessonModel() { id = 2, teacherId = 1, studentId = 2, date = DateTime.Now.AddDays(-50).AddHours(-3).AddMinutes(231) },
                    new LessonModel() { id = 3, teacherId = 2, studentId = 3, date = DateTime.Now.AddYears(-1).AddMonths(4).AddMinutes(854) },
                    new LessonModel() { id = 4, teacherId = 2, studentId = 2, date = DateTime.Now.AddDays(-1).AddMonths(3).AddMinutes(213) },
                    new LessonModel() { id = 5, teacherId = 2, studentId = 3, date = DateTime.Now.AddHours(-42).AddDays(34).AddMinutes(23) }
                );

            // -------------- Seed End -------------- //
        }
    }
}
