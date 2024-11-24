using Microsoft.EntityFrameworkCore;
using StudentAttendanceAPI.Models;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Attendance> Attendances { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public static void Seed(AppDbContext context)
    {
        if (!context.Students.Any())
        {
            context.Students.AddRange(
                new Student { Name = "Ahmed", Age = 22 },
                new Student { Name = "Mona", Age = 20 }
            );
            context.SaveChanges();
        }
    }
}
