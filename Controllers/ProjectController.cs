using Microsoft.AspNetCore.Mvc;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Controllers;

[ApiController]
[Route("/api/v1/projects")]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        return Ok(await projectService.GetAllProjects());
    }

    [HttpGet("{id}", Name = "GetProjectById")]
    public async Task<IActionResult> GetProjectById([FromRoute] int id)
    {
        Models.Project? project = await projectService.GetProjectById(id);
        return project is not null
            ? Ok(project)
            : NotFound($"Project with ID: {id} does not exist.");
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] Models.Project project)
    {
        project.CreatedAt = DateTime.UtcNow;
        project.ModifiedAt = DateTime.UtcNow;
        
        await projectService.AddProject(project);
        return CreatedAtRoute("GetProjectById", new { id = project.ProjectId }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] Models.Project project)
    {
        Models.Project? entry = await projectService.GetProjectById(id);

        if (entry is null)
        {
            return NotFound($"Project with ID: {id} does not exist.");
        }

        try
        {
            project.ModifiedAt = DateTime.UtcNow;
            await projectService.UpdateProject(entry, project);
            return NoContent();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int id)
    {
        Models.Project? project = await projectService.GetProjectById(id);

        if (project is null)
        {
            return NotFound($"Project with ID: {id} does not exist.");
        }

        await projectService.DeleteProject(project);
        return NoContent();
    }
}