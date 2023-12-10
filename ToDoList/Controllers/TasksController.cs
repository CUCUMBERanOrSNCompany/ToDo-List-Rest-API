// TasksController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Entities;
using ToDoList.Services;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(Guid id)
    {
        try
        {
            var task = _taskService.GetTaskById(id);
            return Ok(task);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] CustomerTask task)
    {
        try
        {
            _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(Guid id, [FromBody] CustomerTask updatedTask)
    {
        try
        {
            _taskService.UpdateTask(id, updatedTask);
            return RedirectToAction(nameof(GetTask), new { id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(Guid id)
    {
        _taskService.DeleteTask(id);
        return RedirectToAction(nameof(GetTasks));
    }
}