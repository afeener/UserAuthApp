using UserAuthApp.Domain.Interfaces;

namespace UserAuthApp.Infrastructure.Notifications
{
    public class ConsoleNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}
