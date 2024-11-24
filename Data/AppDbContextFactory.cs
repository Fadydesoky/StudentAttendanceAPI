using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentAttendanceAPI
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-KI9AI6G\\SQLEXPRESS;Database=AttendanceDb;Trusted_Connection=True;Encrypt=False;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
