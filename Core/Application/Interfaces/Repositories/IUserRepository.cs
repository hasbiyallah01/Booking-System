using Booking_System.Core.Entity.Models;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserbyStudentId(string studentId);
        Task<User> GetUserById(int Id);
        Task<User> GetUser(Expression<Func<User, bool>> predicate);
        User UpdateAsync(User user);
        void RemoveUser(User user);
    }
}
