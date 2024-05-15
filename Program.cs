using Microsoft.EntityFrameworkCore;

using SoftwareSystems;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database>(optionsAction => optionsAction.UseInMemoryDatabase("software-systems"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
