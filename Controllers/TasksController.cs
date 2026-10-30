using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.DTOs;
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
    public ActionResult<List<TaskDto>> GetAll()
    {
        return Ok(_tasks.Select(MapToDto).ToList());
    }

    // GET api/tasks/2
    [HttpGet("{id}")]
    public ActionResult<TaskDto> GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
            return NotFound();

        return Ok(MapToDto(task));
    }

    // POST api/tasks
    [HttpPost]
    public ActionResult<TaskDto> Create(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Id = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1,
            Title = dto.Title,
            Description = dto.Description
        };

        _tasks.Add(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, MapToDto(task));
    }

    // PUT api/tasks/2
    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateTaskDto dto)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
            return NotFound();

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.IsCompleted = dto.IsCompleted;

        return NoContent();
    }

    // DELETE api/tasks/3
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
            return NotFound();

        _tasks.Remove(task);

        return NoContent();
    }

    private static TaskDto MapToDto(TaskItem task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,     
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }
}