namespace ToDoList.Entities;

/// <summary>
/// Holds a task
/// </summary>
public class CustomerTask
{
    /// <summary>
    /// The title of the task
    /// </summary>
    public string Title
    {
        get => _title;

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Customer did not provided title for the task.");
            }

            _title = value;
        }
    }

    /// <summary>
    /// Storing the actual title of the task
    /// </summary>
    private string _title;

    /// <summary>
    /// The description of the task
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The date by which the task is expected to be completed
    /// </summary>
    public DateTime DueDate
    {
        get => _dueDate;
        
        set
        {
            // Checks if the provided due date is in the future/Provided at all.
            if (value < DateTime.Now)
            {
                throw new ArgumentException($"Due date must be in the future.");
            }
            
            _dueDate = value;
        }
    }

    /// <summary>
    /// Storing the actual due date value
    /// </summary>
    private DateTime _dueDate;


    /// <summary>
    /// The current status of the task
    /// </summary>
    public Status TaskStatus { get; set; }

    /// <summary>
    /// Id of the task. MAY BE SET ONLY AT INITIALIZATION OF THE OBJECT 
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// We generate the Guid at time of initialization.
    /// </summary>
    public CustomerTask()
    {
        Id = Guid.NewGuid();
        _title = $"";
        Description = $"";
    }
}