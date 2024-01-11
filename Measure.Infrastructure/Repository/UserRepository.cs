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
        private readonly IUserDbContext context;
        public async Task AddUserAsync(User user, CancellationToken ct = default)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

        }

        public Task ChangeEmail(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            return Task.CompletedTask;
            //await Task.FromResult(context.Users.Update(user));
        }

        public Task ChangePassword(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            return Task.CompletedTask;
            //await Task.FromResult(context.Users.Update(user));
        }

        public async Task<User> GetUserByGuid(Guid id, CancellationToken ct = default)
        {
            
            return context.User.FirstOrDefault(u  => u.Id == id);
        }
    }
}
