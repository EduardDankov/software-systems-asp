using Microsoft.EntityFrameworkCore;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Services;

public class ProjectService(Database context) : IProjectService
{
    public async Task<List<Models.Project>> GetAllProjects()
    {
        return await context.Projects.ToListAsync();
    }

    public async Task<Models.Project?> GetProjectById(int id)
    {
        return await context.Projects.FindAsync(id);
    }

    public async Task AddProject(Models.Project project)
    {
        context.Projects.Add(project);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProject(Models.Project entry, Models.Project value)
    {
        context.Entry(entry).CurrentValues.SetValues(value);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProject(Models.Project project)
    {
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
    }
}