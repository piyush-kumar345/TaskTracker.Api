using TaskTracker.Api.DTOs;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learn C# basics", IsCompleted = true },
        new TaskItem { Id = 2, Title = "Build TaskTracker API", Description = "Week 1 project" },
        new TaskItem { Id = 3, Title = "Learn EF Core" }
    };

    public List<TaskDto> GetAll()
    {
        return _tasks.Select(MapToDto).ToList();
    }

    public TaskDto? GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return task is null ? null : MapToDto(task);
    }

    public TaskDto Create(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Id = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1,
            Title = dto.Title,
            Description = dto.Description
        };

        _tasks.Add(task);
        return MapToDto(task);
    }

    public bool Update(int id, UpdateTaskDto dto)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
            return false;

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.IsCompleted = dto.IsCompleted;
        return true;
    }

    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
            return false;

        _tasks.Remove(task);
        return true;
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