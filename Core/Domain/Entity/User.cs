using Booking_System.Core.Domain.Entity;

namespace Booking_System.Core.Entity.Models
{
    public class User : Auditables
    {
        public string? StudentId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();  
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();    
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
