using Microsoft.AspNetCore.Mvc;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Controllers;

[ApiController]
[Route("/api/v1/tasks")]
public class TaskController(ITaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        return Ok(await taskService.GetAllTasks());
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetTaskCount()
    {
        List<Models.Task> tasks = await taskService.GetAllTasks();
        return Ok(tasks.Count);
    }

    [HttpGet("project/{id}")]
    public async Task<IActionResult> GetTasksByProjectId(int id)
    {
        List<Models.Task> tasks = await taskService.GetAllTasks();
        return Ok(tasks.Where(task => task.ProjectId == id));
    }

    [HttpGet("{id}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTaskById([FromRoute] int id)
    {
        Models.Task? task = await taskService.GetTaskById(id);
        return task is not null
            ? Ok(task)
            : NotFound($"Task with ID: {id} does not exist.");
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] Models.Task task)
    {
        task.CreatedAt = DateTime.UtcNow;
        task.ModifiedAt = DateTime.UtcNow;
        if (task.Deadline == default)
        {
            task.Deadline = DateTime.UtcNow.AddMonths(1);
        }
        
        await taskService.AddTask(task);
        return CreatedAtRoute("GetTaskById", new { id = task.TaskId }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] Models.Task task)
    {
        Models.Task? entry = await taskService.GetTaskById(id);

        if (entry is null)
        {
            return NotFound($"Task with ID: {id} does not exist.");
        }

        try
        {
            task.ModifiedAt = DateTime.UtcNow;
            await taskService.UpdateTask(entry, task);
            return NoContent();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask([FromRoute] int id)
    {
        Models.Task? project = await taskService.GetTaskById(id);

        if (project is null)
        {
            return NotFound($"Task with ID: {id} does not exist.");
        }

        await taskService.DeleteTask(project);
        return NoContent();
    }
}