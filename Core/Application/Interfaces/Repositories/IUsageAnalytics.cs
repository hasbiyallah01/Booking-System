using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IUsageAnalytics
    {
        Task<UsageAnalytics> AddAsync(UsageAnalytics usageAnalytics);
        Task<UsageAnalytics> GetAsyncByZoneId(int zoneId);
        Task<UsageAnalytics> GetAsyncById(int id);
        Task<UsageAnalytics> GetAsync(Expression<Func<UsageAnalytics, bool>> predicate);
        Task<ICollection<UsageAnalytics>> GetAllAsync(Expression<Func<UsageAnalytics, bool>> predicate);
        Task<ICollection<UsageAnalytics>> GetAllAsync();
        UsageAnalytics Update(UsageAnalytics usageAnalytics);
        void Remove(UsageAnalytics usageAnalytics);
    }
}
