using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repository.Data;
using LatDBfirstAPI.Repotitory.Contract;
using LatDBfirstAPI.Repotitory.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddTransient<IEmployee,EmployeesRepository>();
builder.Services.AddTransient<IUniversity, UniversitiesRepository>();
builder.Services.AddTransient<IEducations, EducationsRepository>();
builder.Services.AddTransient<IProfiling, ProfilingRepository>();
builder.Services.AddTransient<IAccountRepository, AcountRepository>();
builder.Services.AddTransient<IAccountRole, AccountRoleRepository>();
builder.Services.AddTransient<IRole, RoleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
