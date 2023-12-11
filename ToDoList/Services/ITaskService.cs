using ToDoList.Entities;

namespace ToDoList.Services;

/// <summary>
/// Abstracting Task Service to make it easier for mocking.
/// </summary>
public interface ITaskService
{
    List<CustomerTask> GetAllTasks();
}
