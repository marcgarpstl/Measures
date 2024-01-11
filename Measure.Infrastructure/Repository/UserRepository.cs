using Measure.Domain.Entities;
using Measure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        // private readonly IUserDbContext context;
        public async Task AddUserAsync(User user, CancellationToken ct = default)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

        }
    }
}
