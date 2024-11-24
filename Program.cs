using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// إضافة خدمات الـ DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// إضافة الخدمات المخصصة
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddControllers();

// إضافة Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Attendance API", Version = "v1" });
});

var app = builder.Build();

// استدعاء دالة Seed لتعبئة البيانات
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    AppDbContext.Seed(context); // تعبئة البيانات
}

// إعداد Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Attendance API v1"));
}

app.Run();
