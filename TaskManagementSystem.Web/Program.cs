using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManagementSystem.Application.ApplicationServices;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;
using TaskManagementSystem.Infrastucture.Data;
using TaskManagementSystem.Infrastucture.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency Injection
builder.Services.AddScoped<IUserRepository<User, int>, UserRepository>();
builder.Services.AddScoped<IProjectRepository<Project, int>, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository<Tasks, int>, TaskRepository>();
builder.Services.AddScoped<INotificationRepository<Notification, int>, NotificationRepository>();
//Services DI
builder.Services.AddScoped<ITaskAppService, TaskAppService>();
builder.Services.AddScoped<IProjectAppService, ProjectAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<INotificationAppService, NotificationAppService>();

//Background service

    builder.Services.AddHostedService<NotificationService>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
