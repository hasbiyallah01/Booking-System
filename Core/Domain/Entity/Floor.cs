using Booking_System.Core.Entity.Models;

namespace Booking_System.Core.Domain.Entity
{
    public class Floor : Auditables
    {
        public int FloorNumber { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Zone> Zones { get; set; } = new List<Zone>();


    }
}
