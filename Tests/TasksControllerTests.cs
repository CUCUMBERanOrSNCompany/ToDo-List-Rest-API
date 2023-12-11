using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ToDoList.Entities;
using ToDoList.Services;
using ToDoList.Controllers;
using Xunit;

namespace Tests
{
    /// <summary>
    /// We are testing the CRUD operations
    /// </summary>
    public class TasksControllerTests
    {
        /// <summary>
        /// GetAllTasks:
        /// We pass two tasks.
        /// We expect to get a result which is a list with two tasks.
        /// </summary>
        [Fact]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            var tasksController = new TasksController(mockTaskService.Object);

            // Set up mock data
            var task1 = new CustomerTask { DueDate = DateTime.Now.AddDays(0), TaskStatus = Status.Pending };
            var task2 = new CustomerTask { DueDate = DateTime.Now.AddDays(1), TaskStatus = Status.Pending };
            var tasks = new List<CustomerTask> { task1, task2 };
            mockTaskService.Setup(service => service.GetAllTasks()).Returns(tasks);

            // Act
            var result = tasksController.GetTasks() as OkObjectResult;

            // Assert
            Assert.NotNull(result);

            // Ensure the result is of the correct type
            Assert.IsType<OkObjectResult>(result);

            // Ensure the value inside the result is a list of tasks
            var taskList = result.Value as List<CustomerTask>;
            Assert.NotNull(taskList);

            // Check the number of tasks returned
            Assert.Equal(tasks.Count, taskList.Count);
        }
    }
}
