namespace SoftwareSystems.Interfaces;

public interface IProjectService
{
    Task<List<Models.Project>> GetAllProjects();
    Task<Models.Project?> GetProjectById(int id);
    Task AddProject(Models.Project project);
    Task UpdateProject(Models.Project entry, Models.Project value);
    Task DeleteProject(Models.Project project);
}
