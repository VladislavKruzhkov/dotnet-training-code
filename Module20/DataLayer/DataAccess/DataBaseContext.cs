using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dataInitializer = new DataBaseInitializer();

            modelBuilder.Entity<Student>().HasData(dataInitializer.InitStudents());

            modelBuilder.Entity<Professor>().HasData(dataInitializer.InitProfessors());

            modelBuilder.Entity<Subject>().HasData(dataInitializer.InitSubjects());

            modelBuilder.Entity<Attendance>().HasData(dataInitializer.InitAttendance());
        }
    }
}