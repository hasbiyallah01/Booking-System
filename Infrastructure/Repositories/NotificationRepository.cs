using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class NotificationRepository : INotifcationRepository
    {
        private readonly BookingContext _context;
        public NotificationRepository(BookingContext)
        public Task<Notification> AddAsync(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsync(Expression<Func<Notification, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsyncByBookingId(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsyncByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Notification Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
