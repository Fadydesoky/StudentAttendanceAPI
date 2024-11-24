using Microsoft.EntityFrameworkCore;
using StudentAttendanceAPI.Models;

public class StudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    // إضافة طالب جديد
    public async Task<Student> AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    // جلب جميع الطلاب
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    // جلب طالب محدد
    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Students.FindAsync(studentId);
#pragma warning restore CS8603 // Possible null reference return.
    }

    // تحديث بيانات طالب
    public async Task<Student> UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }

    // حذف طالب
    public async Task DeleteStudentAsync(int studentId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
