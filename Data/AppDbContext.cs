using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Courses_2024.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Online_Courses_2024.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Progress>().HasKey(p => new
            {
                p.UserId,
                p.LessonId
            });
            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole()
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "Student",
                     NormalizedName = "student",
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Instructor",
                    NormalizedName = "instructor",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                   new IdentityRole()
                   {
                       Id = Guid.NewGuid().ToString(),
                       Name = "SuperAdmin",
                       NormalizedName = "superAdmin",
                       ConcurrencyStamp = Guid.NewGuid().ToString()
                   }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }  

        public DbSet<Progress> progresses { get; set; }
    }
}
