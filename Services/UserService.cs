using Microsoft.EntityFrameworkCore;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Services;

public class UserService(Database context) : IUserService
{
    public async Task<List<Models.User>> GetAllUsers()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<Models.User?> GetUserById(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<Models.User?> GetUserByEmail(string email)
    {
        var users = await context.Users.Where(user => user.Email == email).ToListAsync();
        return users.Count > 0 ? users[0] : null;
    }

    public async Task AddUser(Models.User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUser(Models.User entry, Models.User value)
    {
        context.Entry(entry).CurrentValues.SetValues(value);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUser(Models.User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}
