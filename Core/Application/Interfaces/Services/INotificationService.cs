using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Domain.Enum;

namespace Booking_System.Core.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendBookingConfirmationAsync(Booking booking);
        Task SendBookingReminderAsync(Booking booking);
        Task SendCheckInReminderAsync(Booking booking);
        Task SendSessionEndingWarningAsync(Booking booking);
        Task SendBookingCancellationAsync(Booking booking);
        Task SendBookingExpiredAsync(Booking booking);
        Task CreateNotificationAsync(int userId, NotificationType type, string message, int? bookingId = null);
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId);
        Task MarkNotificationAsReadAsync(int notificationId);
        Task MarkAllNotificationsAsReadAsync(int userId);
        Task<int> GetUnreadNotificationCountAsync(int userId);
    }
}
