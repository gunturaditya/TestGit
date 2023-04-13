using Microsoft.EntityFrameworkCore;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;
using WebStudy1.Repotitory.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults
    .AuthenticationScheme).AddCookie(option =>
    {
        option.LoginPath = "/Account/Login";
        option.AccessDeniedPath = "/Account/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUniversity, UniversitiesRepository>();
builder.Services.AddScoped<IEducations, EducationsRepository>();
builder.Services.AddScoped<IProfiling, ProfilingRepository>();
builder.Services.AddScoped<IEmployee, EmployeesRepository>();
builder.Services.AddScoped<IAccountRepository, AcountRepository>();


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

app.UseAuthentication();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
