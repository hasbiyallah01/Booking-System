using Booking_System.Core.Domain.Enum;
using System.Security.Policy;

namespace Booking_System.Models.SeatModel
{
    public class SeatResponse
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string Label { get; set;  }
        public SeatStatus SeatStatus { get; set; }
        public string Amenities { get; set; }
        public bool IsActive { get; set; }
        public Zone Zone { get; set; }
    }
}
