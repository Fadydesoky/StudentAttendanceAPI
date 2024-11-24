using Microsoft.EntityFrameworkCore;
using StudentAttendanceAPI.Models;

public class AttendanceService
{
    private readonly AppDbContext _context;

    public AttendanceService(AppDbContext context)
    {
        _context = context;
    }

    // إضافة تسجيل حضور جديد
    public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
        return attendance;
    }

    // جلب جميع الحضور
    public async Task<List<Attendance>> GetAllAttendancesAsync()
    {
        return await _context.Attendances.ToListAsync();
    }

    // جلب الحضور لطالب معين
    public async Task<List<Attendance>> GetAttendanceByStudentIdAsync(int studentId)
    {
        return await _context.Attendances
            .Where(a => a.StudentId == studentId)
            .ToListAsync();
    }

    // تحديث تسجيل حضور
    public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
    {
        _context.Attendances.Update(attendance);
        await _context.SaveChangesAsync();
        return attendance;
    }

    // حذف تسجيل حضور
    public async Task DeleteAttendanceAsync(int attendanceId)
    {
        var attendance = await _context.Attendances.FindAsync(attendanceId);
        if (attendance != null)
        {
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
