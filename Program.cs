var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
