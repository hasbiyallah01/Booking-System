using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Domain.Enum;

namespace Booking_System.Core.Entity.Models
{
    public class User : Auditables
    {
        public string? StudentId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = Role.Student;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();  
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();    
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
