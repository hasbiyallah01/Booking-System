using Booking_System.Core.Domain.Enum;
using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class AuditLog : Auditables
    {
        public int? UserId { get; set; }
        public int? BookingId { get; set; }
        public AuditAction AuditAction { get; set; }
        public string Details { get; set; } = "{}";
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public User? User { get; set; }
        public Booking? Booking { get; set; }

    }
}
