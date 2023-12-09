using System;
using System.Collections.Generic;
using ToDoList.Entities;

namespace ToDoList.Services
{
    /// <summary>
    /// Service for checking and updating task statuses based on due dates.
    /// </summary>
    public class DueDateCheckerService
    {
        /// <summary>
        /// List of tasks
        /// </summary>
        private readonly List<CustomerTask> _tasks;

        /// <summary>
        /// Settings _tasks to be the list of tasks provided
        /// </summary>
        /// <param name="tasks">The list of tasks</param>
        /// <exception cref="ArgumentNullException">If tasks is null</exception>
        public DueDateCheckerService(List<CustomerTask> tasks)
        {
            _tasks = tasks 
                     ?? throw new ArgumentNullException(nameof(tasks));
        }

        /// <summary>
        /// Checks due dates of tasks and updates their statuses accordingly.
        /// </summary>
        public void CheckAndUpdateDueDates()
        {
            DateTime currentDate = DateTime.Now;

            foreach (var task in _tasks)
            {
                if (task.TaskStatus == Status.Pending && task.DueDate < currentDate)
                {
                    task.TaskStatus = Status.Overdue;
                }
            }
        }
    }
}