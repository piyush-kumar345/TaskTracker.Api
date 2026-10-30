using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.DTOs;
using TaskTracker.Api.Services;

namespace TaskTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET api/tasks
    [HttpGet]
    public ActionResult<List<TaskDto>> GetAll()
    {
        return Ok(_taskService.GetAll());
    }

    // GET api/tasks/2
    [HttpGet("{id}")]
    public ActionResult<TaskDto> GetById(int id)
    {
        var task = _taskService.GetById(id);

        if (task is null)
            return NotFound();

        return Ok(task);
    }

    // POST api/tasks
    [HttpPost]
    public ActionResult<TaskDto> Create(CreateTaskDto dto)
    {
        var created = _taskService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT api/tasks/2
    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateTaskDto dto)
    {
        if (!_taskService.Update(id, dto))
            return NotFound();

        return NoContent();
    }

    // DELETE api/tasks/3
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_taskService.Delete(id))
            return NotFound();

        return NoContent();
    }
}   