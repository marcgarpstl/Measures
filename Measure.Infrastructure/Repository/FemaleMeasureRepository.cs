using Measure.Domain.Entities;
using Measure.Domain.Repositories;
using Measure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Repository
{
    public class FemaleMeasureRepository : IFemaleMeasureRepository
    {
        private readonly IUserDbContext _context;
        public async Task AddMeasureFemaleAsync(FemaleMeasures female, CancellationToken ct = default)
        {
            if (female == null) throw new ArgumentNullException(nameof(female));

            await _context.FemaleMeasures.AddAsync(female, ct);
        }

        public Task DeleteMeasureFemaleAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetFemaleMeasuresByIdAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMeasuresAsync(FemaleMeasures female)
        {
            throw new NotImplementedException();
        }
    }
}
