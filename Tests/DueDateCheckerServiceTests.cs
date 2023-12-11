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
        /// <summary>
        /// We set a task with state pending and past due date.
        /// We expect the DueDateCheckerService to update its state to overdue.
        /// </summary>
        [Fact]
        public void CheckAndUpdateDueDates_Should_UpdateOverdueTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
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
        
        /// <summary>
        /// We set a task with state pending and future due date.
        /// We expect the DueDateCheckerService NOT to update its state.
        /// </summary>
        [Fact]
        public void CheckAndUpdateDueDates_Should_Not_UpdateFutureTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<DueDateCheckerService>>();

            var dueDateCheckerService = new DueDateCheckerService(mockTaskService.Object, mockLogger.Object);

            // Set up tasks with one future task
            var notOverdueTask = new CustomerTask { DueDate = DateTime.Now.AddDays(+1), TaskStatus = Status.Pending };
            var tasks = new List<CustomerTask> { notOverdueTask };

            mockTaskService.Setup(service => service.GetAllTasks()).Returns(tasks);

            // Act
            dueDateCheckerService.CheckAndUpdateDueDates();

            // Assert
            Assert.Equal(Status.Pending, notOverdueTask.TaskStatus);
        }
        
        /// <summary>
        /// We set a task with state In_Progress and past due date.
        /// We expect the DueDateCheckerService NOT to update its state.
        /// </summary>
        [Fact]
        public void CheckAndUpdateDueDates_Should_Not_UpdateInProgressTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<DueDateCheckerService>>();

            var dueDateCheckerService = new DueDateCheckerService(mockTaskService.Object, mockLogger.Object);

            // Set up tasks with one overdue task
            var overdueTask = new CustomerTask { DueDate = DateTime.Now.AddDays(-1), TaskStatus = Status.In_Progress };
            var tasks = new List<CustomerTask> { overdueTask };

            mockTaskService.Setup(service => service.GetAllTasks()).Returns(tasks);

            // Act
            dueDateCheckerService.CheckAndUpdateDueDates();

            // Assert
            Assert.Equal(Status.In_Progress, overdueTask.TaskStatus);
        }
        
        /// <summary>
        /// We set a task with state Completed and past due date.
        /// We expect the DueDateCheckerService NOT to update its state.
        /// </summary>
        [Fact]
        public void CheckAndUpdateDueDates_Should_Not_UpdateCompletedTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<DueDateCheckerService>>();

            var dueDateCheckerService = new DueDateCheckerService(mockTaskService.Object, mockLogger.Object);

            // Set up tasks with one overdue task
            var overdueTask = new CustomerTask { DueDate = DateTime.Now.AddDays(-1), TaskStatus = Status.Completed };
            var tasks = new List<CustomerTask> { overdueTask };

            mockTaskService.Setup(service => service.GetAllTasks()).Returns(tasks);

            // Act
            dueDateCheckerService.CheckAndUpdateDueDates();

            // Assert
            Assert.Equal(Status.Completed, overdueTask.TaskStatus);
        }
    }
}