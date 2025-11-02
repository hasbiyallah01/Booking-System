using Booking_System.Core.Application.Interfaces.Repositories;
using Booking_System.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_System.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingContext _context;

        public UserRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            return user;
        }

        public async Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> predicate)
        {
            var users = await _context.Set<User>()
                        .Where(predicate)
                        .Where(a => !a.IsDeleted)
                        .ToListAsync();
            return users;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var users = await _context.Users.Where(a => !a.IsDeleted)
                        .ToListAsync();
            return users;
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Set<User>().Where(a => !a.IsDeleted)
                .FirstOrDefaultAsync(predicate);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Set<User>()
                .Where(a => !a.IsDeleted)
                .FirstOrDefaultAsync(a => a.Email == email);

            return user;
        }

        public async Task<User> GetUserById(int Id)
        {
            var user = await _context.Set<User>()
                .Where(a => !a.IsDeleted)
                .FirstOrDefaultAsync(a => a.Id == Id);

            return user;
        }

        public async Task<User> GetUserbyStudentId(string studentId)
        {
            var user = await _context.Users
                .Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(a => a.StudentId == studentId);

            return user;
        }

        public void RemoveUser(User user)
        {
            user.IsDeleted = true;
             _context.Set<User>().Update(user);
        }

        public User UpdateAsync(User user)
        {
            _context.Set<User>().Update(user);
            return user;
        }
    }
}
