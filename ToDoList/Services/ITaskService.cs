using ToDoList.Entities;

namespace ToDoList.Services;

/// <summary>
/// Abstracting Task Service to make it easier for mocking.
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Returning all tasks.
    /// </summary>
    /// <returns>The entire list of tasks</returns>
    List<CustomerTask> GetAllTasks();
    
    /// <summary>
    /// Returning a specific task with the corresponding Id.
    /// </summary>
    /// <param name="id">The id of the task we inquire about</param>
    /// <returns>A Task object with the corresponding Id.</returns>
    CustomerTask GetTaskById(Guid id);

    /// <summary>
    /// Creating a task and adding it to data structure of tasks.
    /// </summary>
    /// <param name="task">The task details</param>
    void CreateTask(CustomerTask task);

    /// <summary>
    /// Updating the details of a task with the corresponding Id.
    /// </summary>
    /// <param name="id">The corresponding Id of the task.</param>
    /// <param name="updatedTask">The updated details of the task.</param>
    void UpdateTask(Guid id, CustomerTask updatedTask);

    /// <summary>
    /// Deleting a task with the corresponding Id.
    /// </summary>
    /// <param name="id">The Id of the task that needs to be deleted.</param>
    void DeleteTask(Guid id);
}
