using Booking_System.Core.Entity.Models;
using System.Linq.Expressions;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserbyStudentId(string studentId);
        Task<bool> ExistsAsync(string email, int id);
        Task<bool> ExistsAsync(string email);
        Task<bool> ExistsAsync(int id);
        Task<User> GetUserById(int Id);
        Task<User> GetUser(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAllAsync();
        User UpdateAsync(User user);
        void RemoveUser(User user);
    }
}
