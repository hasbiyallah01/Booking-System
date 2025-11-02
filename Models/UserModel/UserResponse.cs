
using Booking_System.Core.Domain.Enum;
using Booking_System.Models;

namespace Booking_System.Models.UserModel
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }

    public class LoginResponseModel : BaseResponse
    {
        public string Token { get; set; }
        public UserResponse Data { get; set; }
    }
}
