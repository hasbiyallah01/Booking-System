using Booking_System.Core.Domain.Enum;
using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class Booking : Auditables
    {
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime OriginalEndTime { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Booked;
        public string QRToken { get; set; } = string.Empty;
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? EarlyCheckOutReason { get; set; }
        public DateTime? ExtendedUntil { get; set; }
        public User User { get; set; }
        public Seat Seat { get; set; }

        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
