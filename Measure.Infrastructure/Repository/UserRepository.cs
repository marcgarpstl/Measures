using Measure.Domain.Entities;
using Measure.Domain.Repositories;
using Measure.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDbContext _context;
        public UserRepository(IUserDbContext context)
        {
            this._context = context;
        }
        public async Task AddUserAsync(User user, CancellationToken ct = default)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            await _context.Users.AddAsync(user, ct);
        }

        public async Task ChangeEmailAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            await Task.FromResult(_context.Users.Update(user));
        }

        public async Task ChangePasswordAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            await Task.FromResult(_context.Users.Update(user));
        }

        public async Task DeleteUserAsync(Guid id)
        {
            if (id ==  Guid.Empty) throw new ArgumentNullException("id is null");

            var user = await GetUserByGuidAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException("Can't do");
            }

            await Task.FromResult(_context.Users.Remove(user));
        }

        public async Task<User> GetUserByGuidAsync(Guid id, CancellationToken ct = default)
        {
            if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            return _context.Users.FirstOrDefault(u  => u.Id == id);
        }
    }
}
