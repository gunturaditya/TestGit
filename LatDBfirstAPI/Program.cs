using LatDBfirstAPI.Contexts;
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
