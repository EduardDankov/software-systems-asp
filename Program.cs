using Microsoft.EntityFrameworkCore;

using SoftwareSystems;
using SoftwareSystems.Interfaces;
using SoftwareSystems.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database>(optionsAction => optionsAction.UseInMemoryDatabase("software-systems"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
