using Booking_System.Core.Entity.Models;
using Booking_System.Models;

namespace Booking_System.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<BaseResponse> SendEmailAsync(User user);
        Task<bool> SendEmailAsync(MailReceiverRequest request, MailRequest mail);
        Task<string> SendEmailClient(string msg, string Title, string email);
    }
}
