using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<Booking> AddAsync(Booking booking)
        {
            await _context.Set<Booking>().AddAsync(booking);
            return booking;
        }

        public async Task<ICollection<Booking>> GetAllAsync(Expression<Func<Booking, bool>> predicate)
        {
            var bookings = await _context.Set<Booking>().Where(a => !a.IsDeleted)
                .Where(predicate).ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetAllAsync()
        {
            var bookings = await _context.Set<Booking>().Where(a => !a.IsDeleted)
                .ToListAsync();
            return bookings;
        }

        public async Task<Booking> GetAsync(Expression<Func<Booking, bool>> predicate)
        {
            var booking = await _context.Set<Booking>().Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(predicate);
            return booking;
        }

        public async Task<Booking> GetAsyncById(int id)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);

            return booking;
        }

        public async Task<Booking> GetAsyncByUserId(int userId)
        {
            var booking = await _context.Bookings
                    .FirstOrDefaultAsync(a => a.UserId == userId && !a.IsDeleted);

            return booking;
        }

        public void RemoveBooking(Booking booking)
        {
            booking.IsDeleted = true;
            _context.Bookings.Update(booking);  
        }

        public Booking UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            return booking;
        }
    }
}
