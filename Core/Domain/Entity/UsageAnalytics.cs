using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class UsageAnalytics : Auditables
    {
        public DateOnly Date { get; set; }
        public int Hour { get; set; }
        public int ZoneId { get; set; }
        public int TotalBookings { get; set; } = 0;
        public int TotalCheckins { get; set; } = 0;
        public TimeSpan? AverageDuration { get; set; }
        public int PeakOccupancy { get; set; }

        public Zone Zone { get; set; } = null!;

    }
}
