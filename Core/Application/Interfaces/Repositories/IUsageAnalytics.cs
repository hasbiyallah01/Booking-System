using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IUsageAnalytics
    {
        Task<UsageAnalytics> AddAsync(UsageAnalytics usageAnalytics);
        Task<UsageAnalytics> GetAsyncByZoneId(int soneId);
        Task<UsageAnalytics> GetAsyncById(int id);
        Task<UsageAnalytics> GetAsync(Expression<Func<UsageAnalytics, bool>> predicate);
        Task<UsageAnalytics> Update(UsageAnalytics usageAnalytics);
        void Remove(UsageAnalytics usageAnalytics);
    }
}
