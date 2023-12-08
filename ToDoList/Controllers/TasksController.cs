using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Import the required namespace
using ToDoList.Entities;

namespace ToDoList.Controllers
{
    /// <summary>
    /// Controller for the Tasks system
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        /// <summary>
        /// The list of customer's tasks.
        /// </summary>
        private readonly List<CustomerTask> _tasks;

        /// <summary>
        /// Initializing _tasks
        /// </summary>
        public TasksController()
        {
            _tasks = new List<CustomerTask>();
        }

        /// <summary>
        /// Returning the tasks as an IActionResult
        /// </summary>
        /// <returns>IActionResult object</returns>
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_tasks);
        }

        /// <summary>
        /// Returns a specific task as an IActionResult
        /// </summary>
        /// <param name="id">The Id of the task we want to return</param>
        /// <returns>IActionResult object</returns>
        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            var task = _tasks.Find(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Creating a task and adding it to the _tasks list.
        /// </summary>
        /// <param name="task">The new task details</param>
        /// <returns>IActionResult object Acknowledgement/Error</returns>
        [HttpPost]
        public IActionResult CreateTask([FromBody] CustomerTask task)
        {
            try
            {
                // Set default values or perform additional validation as needed
                task.TaskStatus = Status.Pending;

                _tasks.Add(task);

                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing task with the given Id
        /// </summary>
        /// <param name="id">The Id of the task needed to be updated</param>
        /// <param name="updatedTask">Details of the task</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] CustomerTask updatedTask)
        {
            var existingTask = _tasks.Find(t => t.Id == id);

            if (existingTask == null)
            {
                return NotFound();
            }

            try
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.TaskStatus = updatedTask.TaskStatus;

                return RedirectToAction(nameof(GetTask), new { id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a task with the given Id.
        /// </summary>
        /// <param name="id">The Id of the task needed to be deleted</param>
        /// <returns>IActionResult object Acknowledgement/Error</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var task = _tasks.Find(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _tasks.Remove(task);
            return RedirectToAction(nameof(GetTasks));
        }
    }
}
