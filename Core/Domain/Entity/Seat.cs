using Booking_System.Core.Domain.Enum;
using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class Seat : Auditables
    {
        public int ZoneId { get; set; }
        public int SeatNumber { get; set; }
        public string Label { get; set; } = string.Empty;
        public SeatStatus Status { get; set; } = SeatStatus.Available;
        public string Amenities { get; set; } = "{}";
        public bool IsActive { get; set; } = true;
        public Zone Zone { get; set; }  
        public ICollection<Booking> Booking { get; set; } = new List<Booking>();
    }
}
