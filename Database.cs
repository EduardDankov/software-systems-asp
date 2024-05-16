using Microsoft.EntityFrameworkCore;

namespace SoftwareSystems;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<Models.Project> Projects => Set<Models.Project>();
    public DbSet<Models.Task> Tasks => Set<Models.Task>();
    public DbSet<Models.User> Users => Set<Models.User>();
}