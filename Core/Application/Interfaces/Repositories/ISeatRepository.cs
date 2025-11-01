using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface ISeatRepository
    {
        Task<Seat> AddAsync(Seat seat);
        Task<Seat> GetAsyncById(int id);
        Task<Seat> GetAsyncByZoneId(int zoneId);
        Task<Seat> GetAsyncBySeatNumber(int seatNumber);
        Task<Seat> GetAsync(Expression<Func<Seat, bool>> predicate);
        Seat UpdateAsync(Seat seat);
        void DeleteAsync(Seat seat);
    }
}
