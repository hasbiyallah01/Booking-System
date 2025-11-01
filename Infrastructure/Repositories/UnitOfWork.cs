using Booking_System.Core.Application.Interfaces.Repositories;

namespace Booking_System.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingContext _context;

        public UnitOfWork(BookingContext context)
        {
            _context = context;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
