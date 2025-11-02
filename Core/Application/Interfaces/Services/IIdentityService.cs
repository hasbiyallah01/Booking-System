using Booking_System.Models.UserModel;

namespace Booking_System.Core.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        string GenerateToken(string key, string issuer, UserResponse userResponse);
        bool isTokenValid(string key, string issuer, string token); 
    }
}
