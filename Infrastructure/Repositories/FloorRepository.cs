using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booking_System.Infrastructure.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly BookingContext _context;
        public FloorRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<Floor> AddAsync(Floor floor)
        {
            await _context.Set<Floor>().AddAsync(floor);
            return floor;
        }

        public void DeleteAsync(Floor floor)
        {
            floor.IsDeleted = true;
            _context.Set<Floor>().Update(floor);
        }

        public async Task<ICollection<Floor>> GetAllAsync(Expression<Func<Floor, bool>> predicate)
        {
            var floors = await _context.Set<Floor>().Where(a => !a.IsDeleted)
                            .Where(predicate)
                            .Include(a => a.Zones)
                            .ToListAsync();
            return floors;
        }

        public async Task<ICollection<Floor>> GetAllAsync()
        {
            var floors = await _context.Floors.Where(a => !a.IsDeleted)
                            .Include(a => a.Zones)
                            .ToListAsync();
            return floors;
        }

        public Task<Floor> GetAsync(Expression<Func<Floor, bool>> predicate)
        {
            var floor = _context.Set<Floor>().Where(a => !a.IsDeleted)
                        .Include(a => a.Zones)
                        .SingleOrDefaultAsync(predicate);
            return floor;
        }

        public async Task<Floor> GetFloorById(int id)
        {
            var floor = await _context.Floors.FirstOrDefaultAsync(a => a.Id == id);
            return floor;
        }

        public Floor UpdateAsync(Floor floor)
        {
            _context.Set<Floor>().Update(floor);
            return floor;
        }
    }
}
