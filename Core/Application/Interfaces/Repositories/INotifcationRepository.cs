using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface INotifcationRepository
    {
        Task<Notification> AddAsync(Notification notification);
        Task<Notification> GetAsync(Expression<Func<Notification, bool>> predicate);
        Task<Notification> GetAsyncById(int id);
        Task<Notification> GetAsyncByUserId(int userId);
        Task<Notification> GetAsyncByBookingId(int bookingId);
        Notification Update(Notification notification);
        void RemoveNotification(Notification notification);
    }
}
