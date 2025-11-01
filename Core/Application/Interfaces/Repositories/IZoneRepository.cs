using System.Linq.Expressions;
using System.Security.Policy;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IZoneRepository
    {
        Task<Zone> AddAsync(Zone zone);
        Task<Zone> GetAsyncById(int id);
        Task<Zone> GetAsync(Expression<Func<Zone, bool>> predicate);
        Task<Zone> UpdateAsync(Zone zone);
        Task<Zone> DeleteAsync(Zone zone);
    }
}
