namespace Reservas.Domain.Services
{
    public interface INotificationService
    {
        Task SendAsync(string recipientEmail, string subject, string message);
    }
}
