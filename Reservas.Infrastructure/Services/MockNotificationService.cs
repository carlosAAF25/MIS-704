using System;
using System.Threading.Tasks;
using Reservas.Domain.Services;

namespace Reservas.Infrastructure.Services
{
    public class MockNotificationService : INotificationService
    {
        public Task SendAsync(string recipientEmail, string subject, string message)
        {
            Console.WriteLine("Mock Notification Sent");
            Console.WriteLine($"To: {recipientEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
            return Task.CompletedTask;
        }
    }
}
