namespace SoftwareSystems.Interfaces;

public interface ITaskService
{
    Task<List<Models.Task>> GetAllTasks();
    Task<Models.Task?> GetTaskById(int id);
    Task AddTask(Models.Task task);
    Task UpdateTask(Models.Task entry, Models.Task value);
    Task DeleteTask(Models.Task task);
}
