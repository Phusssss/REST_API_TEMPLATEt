using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATE.Models;

namespace REST_API_TEMPLATE.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSCourses> StudentSCoursess { get;set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Define relationship between students and courses through StudentCourse
            builder.Entity<StudentSCourses>()
                .HasKey(sc => new { sc.StudentID, sc.CourseId });

            builder.Entity<StudentSCourses>()
                .HasOne(sc => sc.Students)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentID);

            builder.Entity<StudentSCourses>()
                .HasOne(sc => sc.Courses)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
