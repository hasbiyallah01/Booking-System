using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class Zone : Auditables
    {
        public int FloorId { get; set; }    
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public string Amenities { get; set; } = "{}";
        public bool IsActive { get; set; } = true;
        public Floor Floor { get; set; } = null!;
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<UsageAnalytics> UsageAnalytics { get; set; } = new List<UsageAnalytics>();


    }
}
