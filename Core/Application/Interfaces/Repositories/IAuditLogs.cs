using Booking_System.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IAuditLogs
    {
        Task<AuditLog> AddAsync(AuditLog auditLog);
        Task<AuditLog> GetAsync(Expression<Func<AuditLog, bool>> expression);
        Task<AuditLog> GetAsyncById(int id);
        Task<AuditLog> GetAsyncByUserId(int userId);
        Task<AuditLog> GetAsyncByBookingId(int bookingId); 
        Task<ICollection<AuditLog>> GetAllAsync(Expression<Func<AuditLog, bool>> expression);
        Task<ICollection<AuditLog>>GetAllAsync();
        AuditLog UpdateAuditLog(AuditLog auditLog);
        void RemoveLog(AuditLog auditLog);
    }
}
