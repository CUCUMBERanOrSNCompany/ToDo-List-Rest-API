// TasksController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Entities;
using ToDoList.Services;

/// <summary>
/// Controller for the tasks
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    /// <summary>
    /// task service object (Dependency Injected)
    /// </summary>
    private readonly TaskService _taskService;

    /// <summary>
    /// Dependencies constructor
    /// </summary>
    /// <param name="taskService">Task Service dependency</param>
    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    /// <summary>
    /// Getting all tasks
    /// </summary>
    /// <returns>Result and the tasks</returns>
    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _taskService.GetAllTasks();
        return Ok(tasks);
    }

    /// <summary>
    /// Getting a specific task
    /// </summary>
    /// <param name="id">Id of the inquired-about task</param>
    /// <returns>Result and the task if successful</returns>
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

    /// <summary>
    /// Creating a task
    /// </summary>
    /// <param name="task">Values of the task</param>
    /// <returns>Result</returns>
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

    /// <summary>
    /// Updating a task
    /// </summary>
    /// <param name="id">The id of the task to update</param>
    /// <param name="updatedTask">New values of the task</param>
    /// <returns>Result</returns>
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

    /// <summary>
    /// Deleting a task
    /// </summary>
    /// <param name="id">Id of the task to be deleted</param>
    /// <returns>Result</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(Guid id)
    {
        _taskService.DeleteTask(id);
        return RedirectToAction(nameof(GetTasks));
    }
}