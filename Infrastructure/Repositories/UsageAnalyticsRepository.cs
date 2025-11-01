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

        public async Task<UsageAnalytics> GetAsyncById(int id)
        {
            var analytics = await _context.Set<UsageAnalytics>()
                .SingleOrDefaultAsync(a => a.Id == id);
            return analytics;
        }

        public async Task<UsageAnalytics> GetAsyncByZoneId(int zoneId)
        {
            var analytics = await _context.UsageAnalytics.SingleOrDefaultAsync(a => a.ZoneId == zoneId && !a.IsDeleted);
            return analytics;
        }

        public void Remove(UsageAnalytics usageAnalytics)
        {
            usageAnalytics.IsDeleted = true;
            _context.Update(usageAnalytics);
        }

        public UsageAnalytics Update(UsageAnalytics usageAnalytics)
        {
            _context.Update(usageAnalytics);
            return usageAnalytics;
        }
    }
}
