using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly BookingContext _context;
        public ZoneRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<Zone> AddAsync(Zone zone)
        {
            await _context.Set<Zone>().AddAsync(zone);
            return zone;
        }

        public void DeleteAsync(Zone zone)
        {
            zone.IsDeleted = true;
            _context.Set<Zone>().Update(zone);
        }

        public async Task<ICollection<Zone>> GetAllAsync(Expression<Func<Zone, bool>> predicate)
        {
            var user = await _context.Set<Zone>()
                            .Where(a => !a.IsDeleted)
                            .Where(predicate)
                            .ToListAsync();
            return user;
        }

        public async Task<ICollection<Zone>> GetAllAsync()
        {
            var user = await _context.Zones.Where(a => !a.IsDeleted)
                            .ToListAsync();
            return user;
        }

        public async Task<Zone> GetAsync(Expression<Func<Zone, bool>> predicate)
        {
            var zone = await _context.Set<Zone>().Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(predicate);
            return zone;
        }

        public async Task<Zone> GetAsyncById(int id)
        {
            var zone = await _context.Zones
                .FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == id);
            return zone;
        }

        public Zone UpdateAsync(Zone zone)
        {
            _context.Set<Zone>().Update(zone);
            return zone;
        }
    }
}
