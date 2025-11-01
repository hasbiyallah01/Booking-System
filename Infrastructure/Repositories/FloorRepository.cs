using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
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
