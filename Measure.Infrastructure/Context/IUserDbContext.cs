using Measure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Context
{
    public interface IUserDbContext : IDisposable
    {
        DbSet<User> User { get; set; }
        DbSet<FemaleMeasures> FemaleMeasures { get; set; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
