using Microsoft.EntityFrameworkCore;

namespace SoftwareSystems;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    
}