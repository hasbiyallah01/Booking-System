using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Domain.Enum;

namespace Booking_System.Models
{
    public class QRValidationResponse
    {
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
        public string Message { get; set; }
        public Booking? Booking { get; set; }
        public QRScanAction ScanAction { get; set; }
        public QRScanAction RecommendedAction { get; set; }

    }
}
