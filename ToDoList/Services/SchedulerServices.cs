
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Services
{
    /// <summary>
    /// This class is responsible for running
    /// certain tasks under given schedule.
    /// </summary>
    public class SchedulerServices : BackgroundService
    {
        /// <summary>
        /// Dependency Injection field getting the service injected.
        /// </summary>
        private readonly IServiceProvider _services;

        /// <summary>
        /// Dictating the sleeping time between every two calls to the service.
        /// </summary>
        private readonly int _sleepDurationInMinutes = 1440;

        /// <summary>
        /// Dependency Constructor
        /// </summary>
        /// <param name="services">The injected services</param>
        public SchedulerServices(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// Async logic that runs the injected services
        /// every _sleepDurationInMinutes
        /// </summary>
        /// <param name="stoppingToken">Stopping token.</param>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    // Resolve DueDateCheckerService from the service provider
                    var dueDateCheckerService = scope.ServiceProvider.GetRequiredService<DueDateCheckerService>();

                    // Execute logic to check and update due dates
                    dueDateCheckerService.CheckAndUpdateDueDates();
                }

                // Sleep for the duration dictated by _sleepDurationInMinutes
                await Task.Delay(TimeSpan.FromMinutes(_sleepDurationInMinutes), stoppingToken);
            }
        }
    }
}
