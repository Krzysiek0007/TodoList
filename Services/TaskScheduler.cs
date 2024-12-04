using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using TodoList.Data;

namespace TodoList.Services
{
    public class TaskScheduler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IUserContext _userContext;

        public TaskScheduler(IServiceProvider serviceProvider, IHubContext<NotificationHub> hubContext, IUserContext userContext)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
            _userContext = userContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    if (!string.IsNullOrEmpty(_userContext.UserId))
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                        var upcomingTasks = dbContext.Todos
                            .Where(t => t.User.Id == _userContext.UserId && DateTime.Now <= t.StartTime && t.StartTime <= DateTime.Now.AddMinutes(30))
                            .ToList();

                        foreach (var task in upcomingTasks)
                        {
                            // Logika do wysłania powiadomienia do przeglądarki

                            var message = "Task: " + task.Name
                                            + "\n\tStart time: " + task.StartTime
                                            + "\n\tDescription: " + task.Description;
                            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message, task.Id);
                            Console.WriteLine("Task: " + task.Name + "\n\tStart time: " + task.StartTime + "\n\tDescription: " + task.Description);
                        }
                    }

                }

               await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }

}
