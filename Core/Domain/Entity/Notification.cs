using Booking_System.Core.Domain.Enum;
using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class Notification : Auditables
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; } = null!;
        public Booking? Booking { get; set; }   
    }
}
