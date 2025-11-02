using Booking_System.Core.Domain.Enum;

namespace Booking_System.Models
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }

    public class BaseResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
