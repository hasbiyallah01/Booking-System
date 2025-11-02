using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Domain.Enum;

namespace Booking_System.Models.SeatModel
{
    public class SeatOccupancyInfo
    {
        public int SeatId { get; set; }
        public SeatStatus CurrentStatus { get; set; }
        public Booking? CurrentBooking { get; set; }
        public DateTime? NextBookingStart { get; set; }
        public IEnumerable<Booking> UpcomingBookings { get; set; } = new List<Booking>();

    }
}
 