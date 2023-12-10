using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Entities;
using ToDoList.Services;

namespace ToDoList.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TaskService _tasksService = new TaskService();
        
        [BindProperty]
        public CustomerTask Task { get; set; }

        public void OnGet()
        {
            // This is called when the page is initially loaded
            Task = new CustomerTask();
        }
        
        public IActionResult OnPost()
        {
            // This is called when the form is submitted
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new CustomerTask using the form data
                    var newTask = new CustomerTask
                    {
                        Title = Task.Title,
                        Description = Task.Description,
                        DueDate = Task.DueDate,
                        TaskStatus = Status.Pending // Set default status, or you can set it based on your logic
                    };

                    // Add the new task using the injected service
                    _tasksService.CreateTask(newTask);

                    // Redirect to the task list page
                    return RedirectToPage("/Index");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during task creation
                    ModelState.AddModelError(string.Empty, $"Error creating task: {ex.Message}");
                    return Page();
                }
            }
            // else
            // {
            //     return Page();
            // }

            // ModelState is not valid, log or debug the validation errors
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
            }

            // If the ModelState is not valid, return to the same page with validation errors
            return Page();
        }
    }
}