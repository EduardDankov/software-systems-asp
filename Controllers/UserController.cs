using Microsoft.AspNetCore.Mvc;

using SoftwareSystems.Interfaces;

namespace SoftwareSystems.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await userService.GetAllUsers());
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        Models.User? user = await userService.GetUserById(id);
        return user is not null
            ? Ok(user)
            : NotFound($"User with ID: {id} does not exist.");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] Models.User user)
    {
        await userService.AddUser(user);
        return CreatedAtRoute("GetUserById", new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] Models.User user)
    {
        Models.User? entry = await userService.GetUserById(id);

        if (entry is null)
        {
            return NotFound($"User with ID: {id} does not exist.");
        }

        try
        {
            await userService.UpdateUser(entry, user);
            return NoContent();
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        Models.User? user = await userService.GetUserById(id);

        if (user is null)
        {
            return NotFound($"User with ID: {id} does not exist.");
        }

        await userService.DeleteUser(user);
        return NoContent();
    }
}
