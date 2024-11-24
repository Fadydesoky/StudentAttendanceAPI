namespace StudentAttendanceAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
    public string ?Name { get; set; }  // تأكد من أن هذه الخاصية موجودة
    public int Age { get; set; }        public List<Attendance>? Attendance { get; set; }
    }
}
