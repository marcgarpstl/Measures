using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByAuthIdAsync(string authId, CancellationToken ct = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default);
        Task <User> GetUserByGuidAsync (Guid id, CancellationToken ct = default);
        Task AddUserAsync(User user, CancellationToken ct = default);
        Task ChangePasswordAsync(User user);
        Task ChangeEmailAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
