using Measure.Domain.Repositories;
using Measure.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUserDbContext _userDbContext;
        public UnitOfWork(IUserDbContext userDbContext)
        {
            this._userDbContext = userDbContext;
        }
        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _userDbContext.SaveChangesAsync(ct);
        }
    }
}
