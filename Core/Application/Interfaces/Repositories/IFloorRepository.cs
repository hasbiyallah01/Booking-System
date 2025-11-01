using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IFloorRepository
    {
        Task<Floor> AddAsync(Floor floor);
        Task<Floor> GetFloorById(int id);
        Task<Floor> GetAsync(Expression<Func<Floor, bool>> predicate);
        Floor UpdateAsync(Floor floor);
        void DeleteAsync(Floor floor);
    }
}
