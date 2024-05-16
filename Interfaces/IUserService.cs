namespace SoftwareSystems.Interfaces;

public interface IUserService
{
    Task<List<Models.User>> GetAllUsers();
    Task<Models.User?> GetUserById(int id);
    Task AddUser(Models.User user);
    Task UpdateUser(Models.User entry, Models.User value);
    Task DeleteUser(Models.User user);
}
