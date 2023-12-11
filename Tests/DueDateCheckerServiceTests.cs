using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using ToDoList.Entities;
using ToDoList.Services;
using Xunit;

namespace Tests
{
    public class DueDateCheckerServiceTests
    {
        [Fact]
        public void CheckAndUpdateDueDates_Should_UpdateOverdueTasks()
        {
            // Arrange
            var mockTaskService = new Mock<TaskService>();
            var mockLogger = new Mock<ILogger<DueDateCheckerService>>();

            var dueDateCheckerService = new DueDateCheckerService(mockTaskService.Object, mockLogger.Object);

            // Set up tasks with one overdue task
            var overdueTask = new CustomerTask { DueDate = DateTime.Now.AddDays(-1), TaskStatus = Status.Pending };
            var tasks = new List<CustomerTask> { overdueTask };

            mockTaskService.Setup(service => service.GetAllTasks()).Returns(tasks);

            // Act
            dueDateCheckerService.CheckAndUpdateDueDates();

            // Assert
            Assert.Equal(Status.Overdue, overdueTask.TaskStatus);
        }
    }
}