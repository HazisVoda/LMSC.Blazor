using LMSC.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSC.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Roles Table
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, RoleName = "Admin" });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 2, RoleName = "Leaner" });

            //Seed Course Table
            modelBuilder.Entity<Course>().HasData(
                new Course
                { 
                    CourseID = 001,
                    CourseName = "Calculus 1",
                    CourseDetails = "Calculus 1 Course by Hazis Voda",
                    PhotoPath = "images/Calc1.png"
                });
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 002,
                    CourseName = "Calculus 2",
                    CourseDetails = "Calculus 2 Course by Hazis Voda",
                    PhotoPath = "images/Calc2.png"
                });
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 003,
                    CourseName = "C Programming 1",
                    CourseDetails = "C Programming 1 Course by Hazis Voda",
                    PhotoPath = "images/CProgramming1.png"
                });
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = 004,
                    CourseName = "C Programming 2",
                    CourseDetails = "C Programming 2 Course by Hazis Voda",
                    PhotoPath = "images/CProgramming2.png"
                });

            //Seed User Table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FirstName = "Hazis",
                    LastName = "Voda",
                    Email = "hazisgvoda@outlook.com",
                    RoleID = 1,
                    DateOfBirth = new DateTime(2005, 4, 22),
                    Gender = Gender.Male,
                    PhotoPath = "#"
    });
        }
    }
}
