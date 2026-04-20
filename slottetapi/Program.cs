using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using slotlib.data;
using slottetapi.Services.Employees;
using slottetapi.Services.Responsibilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//erstattet med builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // Tilføj EmployeeService som en scoped service, så den kan injiceres i controllers
builder.Services.AddScoped<IResponsibilityService, ResponsibilityService>(); // Tilføj ResponsibilityService som en scoped service, så den kan injiceres i controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// erstatet med app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
