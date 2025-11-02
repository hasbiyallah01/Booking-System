using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IZoneRepository
    {
        Task<Zone> AddAsync(Zone zone);
        Task<Zone> GetAsyncById(int id);
        Task<Zone> GetAsync(Expression<Func<Zone, bool>> predicate);
        Task<ICollection<Zone>> GetAllAsync(Expression<Func<Zone, bool>> predicate);
        Task<ICollection<Zone>> GetAllAsync();
        Zone UpdateAsync(Zone zone);
        void DeleteAsync(Zone zone);
    }
}
