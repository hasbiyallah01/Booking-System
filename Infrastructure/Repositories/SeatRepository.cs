using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly BookingContext _content;
        public SeatRepository(BookingContext content)
        {
            _content = content;
        }
        public async Task<Seat> AddAsync(Seat seat)
        {
            await _content.Set<Seat>().AddAsync(seat);
            return seat;
        }

        public void DeleteAsync(Seat seat)
        {
            seat.IsDeleted = true;
            _content.Set<Seat>().Update(seat);
        }

        public async Task<ICollection<Seat>> GetAllAsync(Expression<Func<Seat, bool>> predicate)
        {
            var seats = await _content.Seats
                            .Where(predicate)
                            .Where(a => !a.IsDeleted)
                            .Include(a => a.Zone)
                            .ToListAsync();
            return seats;
        }

        public async Task<ICollection<Seat>> GetAllAsync()
        {
            var seats = await _content.Seats
                .Where(a => !a.IsDeleted)
                .Include(a => a.Zone)
                .ToListAsync();
            return seats;
        }

        public Task<Seat> GetAsync(Expression<Func<Seat, bool>> predicate)
        {
            var seat = _content.Set<Seat>()
                        .Where(predicate)
                        .Where(a => !a.IsDeleted)
                        .Include(a => a.Zone)
                        .SingleOrDefaultAsync();
            return seat;
        }

        public async Task<Seat> GetAsyncById(int id)
        {
            var seat = await _content.Seats.SingleOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
            return seat;
        }

        public async Task<Seat> GetAsyncBySeatNumber(int seatNumber)
        {
            var seat = await _content.Seats.SingleOrDefaultAsync(a => a.SeatNumber == seatNumber && !a.IsDeleted);
            return seat;
        }

        public async Task<Seat> GetAsyncByZoneId(int zoneId)
        {
            var seat = await _content.Seats.SingleOrDefaultAsync(a => a.ZoneId == zoneId && !a.IsDeleted);
            return seat;
        }

        public Seat UpdateAsync(Seat seat)
        {
            _content.Seats.Update(seat);
            return seat;
        }
    }
}
