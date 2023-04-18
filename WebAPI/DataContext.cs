using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace WebAPI
{
    public class DataContext : DbContext
    {
        public DbSet<TeacherModel> teachers { get; set; }
        public DbSet<LessonModel> lessons { get; set; }
        public DbSet<StudentModel> students { get; set; }
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
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TeacherModel>()
                .HasOne<LessonModel>(r => r.oil)
                .WithMany(o => o.recipes);

            modelBuilder
                .Entity<LessonModel>()
                .HasOne<StudentModel>(r => r.oil)
                .WithMany(o => o.recipes);
        }
    }
}
