namespace Booking_System.Core.Entity.Models
{
    public class Auditables
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? _dateModified { get; set; }
        public DateTime? DateModified
        {
            get => _dateModified;
            set => _dateModified = value.HasValue ? DateTime.SpecifyKind(value.Value , DateTimeKind.Utc) : (DateTime?)null;
        }

        public DateTime? _dateCreated { get; set; }

        public DateTime? DateCreated
        {
            get => _dateCreated;
            set => _dateCreated = value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : (DateTime?) null;
        }
    }
}
