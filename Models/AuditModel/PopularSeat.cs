namespace Booking_System.Models.AuditModel
{
    public class PopularSeat
    {
        public int SeatId { get; set; }
        public string SeatLabel { get; set;  }
        public string ZoneName { get; set; }
        public int BookingCount { get; set; }
        public TimeSpan TotalUsageTime { get; set; }
    }
}
