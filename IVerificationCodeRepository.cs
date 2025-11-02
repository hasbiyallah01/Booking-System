using System.Linq.Expressions;
using Booking_System.Core.Domain.Entity;

namespace Booking_System.Core.Application.Interfaces.Repositories
{
    public interface IVerificationCodeRepository 
    {
        Task<int> Save();
        Task<VerificationCode> Create(VerificationCode entity);
        VerificationCode Update(VerificationCode entity);
        Task<VerificationCode> Get(int id);
        Task<VerificationCode> Get(string email);
        Task<VerificationCode> Get(Expression<Func<VerificationCode, bool>> expression);
    }
}
