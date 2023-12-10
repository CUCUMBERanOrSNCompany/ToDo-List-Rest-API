using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Entities;

namespace ToDoList.Services
{
    /// <summary>
    /// Service for checking and updating task statuses based on due dates.
    /// </summary>
    public class DueDateCheckerService
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DueDateCheckerService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for dependency injection.</param>
        public DueDateCheckerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Checks due dates of tasks and updates their statuses accordingly.
        /// </summary>
        public void CheckAndUpdateDueDates()
        {
            // Retrieve the list of tasks from the service provider
            var tasks = _serviceProvider.GetService<List<CustomerTask>>();

            if (tasks == null)
            {
                throw new InvalidOperationException(
                    "Unable to resolve tasks list from the service provider.");
            }

            DateTime currentDate = DateTime.Now;

            foreach (var task in tasks)
            {
                // For debugging purposes, you can add logs
                Console.WriteLine($"Task ID: {task.Id}, Due Date: {task.DueDate}, Status: {task.TaskStatus}");

                // Change the status to Overdue regardless of the conditions
                task.TaskStatus = Status.Overdue;

                if (task.TaskStatus == Status.Pending && task.DueDate < currentDate)
                {
                    // You can add logs to trace when the condition is met
                    Console.WriteLine($"Task ID: {task.Id} is Overdue!");
                    task.TaskStatus = Status.Overdue;
                }
            }
        }
    }
}
