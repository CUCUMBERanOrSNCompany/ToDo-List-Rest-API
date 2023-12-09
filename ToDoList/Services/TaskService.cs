using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Entities;

namespace ToDoList.Services
{
    /// <summary>
    /// Responsible for the business logic of the tasks.
    /// </summary>
    public class TaskService
    {
        /// <summary>
        /// List of the tasks
        /// </summary>
        private readonly List<CustomerTask> _tasks;

        /// <summary>
        /// Initiate the tasks list
        /// </summary>
        public TaskService()
        {
            _tasks = new List<CustomerTask>();
        }

        /// <summary>
        /// Returns the tasks
        /// </summary>
        /// <returns>_tasks</returns>
        public List<CustomerTask> GetAllTasks()
        {
            return _tasks;
        }

        /// <summary>
        /// Returns a specific task with a given Id.
        /// </summary>
        /// <param name="id">The id of the task we inquire</param>
        /// <returns>A customer task</returns>
        public CustomerTask GetTaskById(Guid id)
        {
            var output =  _tasks.FirstOrDefault(t => t.Id == id);

            if (output == null)
            {
                throw new Exception($"Invalid task Id!");
            }

            return output;
        }

        /// <summary>
        /// Adding the given task to the _tasks list
        /// </summary>
        /// <param name="task">The task object we inset to the list</param>
        public void CreateTask(CustomerTask task)
        {
            task.TaskStatus = Status.Pending;
            
            _tasks.Add(task);
        }

        /// <summary>
        /// Updating a task with the given Id with the
        /// details of the provided task
        /// </summary>
        /// <param name="id">The id of the task we wish to modify</param>
        /// <param name="updatedTask">The updated details of the task.</param>
        public void UpdateTask(Guid id, CustomerTask updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);

            // The task wasn't found, or the updated details are null,
            // so we return without updating anything.
            if (existingTask == null 
                || updatedTask == null)
            {
                return;
            }
            
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.TaskStatus = updatedTask.TaskStatus;
        }

        /// <summary>
        /// Deleting a task with the given id.
        /// </summary>
        /// <param name="id">The id of the task needs to be deleted.</param>
        public void DeleteTask(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}