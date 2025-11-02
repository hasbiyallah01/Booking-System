using Booking_System.Core.Domain.Entity;
using Booking_System.Models;
using Booking_System.Models.BookingModel;

namespace Booking_System.Core.Application.Interfaces.Services
{
    public interface IBookingService
    {
        Task<BaseResponse<BookingResponse>> CreateBooking(BookingRequest request);
        Task<BaseResponse<bool>> ChcekSeatAvailability(int seatId,DateTime StartTime, DateTime EndTime);
        Task<BaseResponse<BookingResponse?>> GetActiveBooking(int userId);
        Task<BaseResponse<IEnumerable<BookingResponse>>> GetUserBookingsAsync(int userId);
        Task<BaseResponse<bool>> CheckInAsync(int bookingId);
        Task<BaseResponse<bool>> CheckOutAsync(int bookingId);
        Task<BaseResponse<bool>> ExtendBookingAsync(int bookingId, DateTime newEndTime);
        Task<BaseResponse<IEnumerable<Seat>>> GetAvailableSeats(DateTime startTime, DateTime endTime, int? floorId);
        Task<BaseResponse<bool>> CancelBooking(int bookingId);
        Task ProcessExpiredBookingAsync();

    }
}
