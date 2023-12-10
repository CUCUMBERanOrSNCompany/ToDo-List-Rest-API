using ToDoList.Entities;

namespace ToDoList.Services
{
    /// <summary>
    /// Service for checking and updating task statuses based on due dates.
    /// </summary>
    public class DueDateCheckerService
    {
        /// <summary>
        /// The task service responsible for managing tasks.
        /// </summary>
        private readonly TaskService _taskService;

        /// <summary>
        /// The logger for logging messages.
        /// </summary>
        private readonly ILogger<DueDateCheckerService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DueDateCheckerService"/> class.
        /// </summary>
        /// <param name="taskService">The task service for managing tasks.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public DueDateCheckerService(TaskService taskService, ILogger<DueDateCheckerService> logger)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Checks due dates of tasks and updates their statuses accordingly.
        /// </summary>
        public void CheckAndUpdateDueDates()
        {
            //_logger.LogInformation("Checking and updating due dates...");

            DateTime currentDate = DateTime.Now;

            var tasks = _taskService.GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.TaskStatus == Status.Pending 
                    && task.DueDate < currentDate)
                {
                    task.TaskStatus = Status.Overdue;
                }
            }

            //_logger.LogInformation("Check and update complete.");
        }
    }
}
