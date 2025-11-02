using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class NotificationRepository : INotifcationRepository
    {
        private readonly BookingContext _context;
        public NotificationRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<Notification> AddAsync(Notification notification)
        {
            await _context.Set<Notification>().AddAsync(notification);
            return notification;
        }

        public async Task<ICollection<Notification>> GetAllAsync(Expression<Func<Notification, bool>> predicate)
        {
            var notifications = await _context.Set<Notification>().Where(a => !a.IsDeleted)
                                    .Where(predicate)
                                    .ToListAsync();
            return notifications;
        }

        public async Task<ICollection<Notification>> GetAllAsync()
        {
            var notifications = await _context.Notifications.Where(a => !a.IsDeleted)
                .Include(a => a.User)
                .ToListAsync();

            return notifications;
        }

        public async Task<Notification> GetAsync(Expression<Func<Notification, bool>> predicate)
        {
            var notification = await _context.Set<Notification>().Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(predicate);
            return notification;
        }

        public async Task<Notification> GetAsyncByBookingId(int bookingId)
        {
            var notification = await _context.Notifications
                .SingleOrDefaultAsync(a => a.BookingId == bookingId);
            return notification;
        }

        public async Task<Notification> GetAsyncById(int id)
        {
            var notification = await _context.Notifications.SingleOrDefaultAsync(a => a.Id == id);
            return notification;
        }

        public async Task<Notification> GetAsyncByUserId(int userId)
        {
            var notification = await _context.Notifications
                .SingleOrDefaultAsync(a => a.UserId == userId);
            return notification;
        }

        public void RemoveNotification(Notification notification)
        {
            notification.IsDeleted = true;
            _context.Notifications.Update(notification);
        }

        public Notification Update(Notification notification)
        {
            _context.Notifications.Update(notification);
            return notification;
        }
    }
}
