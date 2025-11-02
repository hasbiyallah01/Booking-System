using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class AuditLogs : IAuditLogs
    {
        public BookingContext _context;
        public AuditLogs(BookingContext context)
        {
            _context = context;
        }
        public async Task<AuditLog> AddAsync(AuditLog auditLog)
        {
            await _context.Set<AuditLog>().AddAsync(auditLog);
            return auditLog;
        }

        public async Task<ICollection<AuditLog>> GetAllAsync(Expression<Func<AuditLog, bool>> expression)
        {
            var auditlogs = await _context.Set<AuditLog>()
                .Where(a => !a.IsDeleted)
                .Where(expression)
                .ToListAsync();
            return auditlogs;
        }

        public async Task<ICollection<AuditLog>> GetAllAsync()
        {
            var auditLogs = await _context.AuditLogs.Where(a => !a.IsDeleted)
                .ToListAsync();
            return auditLogs;
        }

        public async Task<AuditLog> GetAsync(Expression<Func<AuditLog, bool>> expression)
        {
            var auditLog = await _context.Set<AuditLog>()
                        .Where(a => !a.IsDeleted)
                        .FirstOrDefaultAsync(expression);
            return auditLog;
        }

        public async Task<AuditLog> GetAsyncByBookingId(int bookingId)
        {
            var auditLog = await _context.AuditLogs.FirstOrDefaultAsync(a => a.BookingId == bookingId);
            return auditLog;
        }

        public async Task<AuditLog> GetAsyncById(int id)
        {
            var auditLog = await _context.AuditLogs.FirstOrDefaultAsync(a => a.Id == id);
            return auditLog;
        }

        public async Task<AuditLog> GetAsyncByUserId(int userId)
        {
            var auditLog = await _context.AuditLogs.FirstOrDefaultAsync(a => a.UserId == userId);
            return auditLog;
        }

        public void RemoveLog(AuditLog auditLog)
        {
            auditLog.IsDeleted = true;
            _context.Set<AuditLog>().Update(auditLog);
        }

        public AuditLog UpdateAuditLog(AuditLog auditLog)
        {
            _context.Set<AuditLog>().Update(auditLog);
            return auditLog;
        }
    }
}
