using Booking_System.Core.Application.Interfaces.Repositories;
using System.Linq.Expressions;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Infrastructure.Repositories
{
    public class UsageAnalyticsRepository : IUsageAnalytics
    {
        private readonly BookingContext _context;
        public UsageAnalyticsRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<UsageAnalytics> AddAsync(UsageAnalytics usageAnalytics)
        {
            await _context.Set<UsageAnalytics>().AddAsync(usageAnalytics);
            return usageAnalytics;
        }

        public async Task<UsageAnalytics> GetAsync(Expression<Func<UsageAnalytics, bool>> predicate)
        {
            var analytics = await _context.Set<UsageAnalytics>().Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(predicate);
            return analytics;
        }

        public Task<UsageAnalytics> GetAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsageAnalytics> GetAsyncByZoneId(int soneId)
        {
            throw new NotImplementedException();
        }

        public void Remove(UsageAnalytics usageAnalytics)
        {
            throw new NotImplementedException();
        }

        public Task<UsageAnalytics> Update(UsageAnalytics usageAnalytics)
        {
            throw new NotImplementedException();
        }
    }
}
