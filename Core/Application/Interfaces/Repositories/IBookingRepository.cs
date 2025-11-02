using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> AddAsync(Booking booking);
        Task<Booking> GetAsyncByUserId(int userId);
        Task<Booking> GetAsyncById(int id); 
        Task<Booking> GetAsync(Expression<Func<Booking, bool>> predicate);
        Task<ICollection<Booking>> GetAllAsync(Expression<Func<Booking, bool>> predicate);
        Task<ICollection<Booking>> GetAllAsync();
        Booking UpdateBooking(Booking booking);
        void RemoveBooking(Booking booking);
    }
}
