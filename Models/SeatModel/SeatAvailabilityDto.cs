namespace Booking_System.Models.SeatModel
{
    public class SeatAvailabilityDto
    {
        public bool IsAvailable { get; set; }
        public string Message { get; set; }
        public DateTime? NextAvailableTime { get; set; }
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
