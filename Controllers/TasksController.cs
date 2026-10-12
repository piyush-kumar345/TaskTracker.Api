using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> _tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learn C# basics", IsCompleted = true },
        new TaskItem { Id = 2, Title = "Build TaskTracker API", Description = "Week 1 project" },
        new TaskItem { Id = 3, Title = "Learn EF Core" }
    };

    // GET api/tasks
    [HttpGet]
    public ActionResult<List<TaskItem>> GetAll()
    {
        return Ok(_tasks);
    }

    // GET api/tasks/2
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
            return NotFound();

        return Ok(task);
    }
}