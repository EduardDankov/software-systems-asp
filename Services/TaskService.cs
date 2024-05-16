using Microsoft.EntityFrameworkCore;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Services;

public class TaskService(Database context) : ITaskService
{
    public async Task<List<Models.Task>> GetAllTasks()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task<Models.Task?> GetTaskById(int id)
    {
        return await context.Tasks.FindAsync(id);
    }

    public async Task AddTask(Models.Task task)
    {
        context.Tasks.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTask(Models.Task entry, Models.Task value)
    {
        context.Entry(entry).CurrentValues.SetValues(value);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTask(Models.Task task)
    {
        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }
}