using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking_System.Core.Domain.Enum
{
    public enum QRScanAction
    {
        CheckIn,
        ChcekOut,
        Invalid,
        Expired,
        AlreadyProcessed
    }
}
