using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Data;
using TaskManagementSystem.Core.Entities.Enums;

public class NotificationService : IHostedService, IDisposable
{
    private readonly IServiceProvider _services;
    private readonly TimeSpan _notificationCheckInterval = TimeSpan.FromHours(1); // Adjust as needed
    private Timer _timer;

    public NotificationService(IServiceProvider services)
    {
        _services = services;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(CheckAndSendNotifications, null, TimeSpan.Zero, _notificationCheckInterval);
        return Task.CompletedTask;
    }

    private void CheckAndSendNotifications(object state)
    {
        using (var scope = _services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Check and send notifications for task due date
            DateTime now = DateTime.Now;
            DateTime dueDateThreshold = now.AddHours(48);
            var tasksDueSoon = dbContext.Tasks
                .Include(t => t.User)
                .Where(t => t.DueDate <= dueDateThreshold && !t.User.Notifications.Any(n => n.Type == "Due Date Reminder" && n.Timestamp > now))
                .ToList();

            foreach (var task in tasksDueSoon)
            {
                // Create and send a notification
                var notification = new Notification
                {
                    Type = "Due Date Reminder",
                    Message = $"Task '{task.Title}' is due soon.",
                    Timestamp = now,
                    UserId = task.UserId
                };

                dbContext.Notifications.Add(notification);
            }

            // Check and send notifications for task completion
            var completedTasks = dbContext.Tasks
                .Include(t => t.User)
                .Where(t => t.Status == Status.Completed && !t.User.Notifications.Any(n => n.Type == "Task Completed" && n.Timestamp > now))
                .ToList();

            foreach (var task in completedTasks)
            {
                // Create and send a notification
                var notification = new Notification
                {
                    Type = "Task Completed",
                    Message = $"Task '{task.Title}' has been completed.",
                    Timestamp = now,
                    UserId = task.UserId
                };

                dbContext.Notifications.Add(notification);
            }

            dbContext.SaveChanges();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
