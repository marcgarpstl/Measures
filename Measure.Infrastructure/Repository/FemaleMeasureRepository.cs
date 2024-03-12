using Measure.Domain.Entities;
using Measure.Domain.Repositories;
using Measure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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
        public FemaleMeasureRepository(IUserDbContext context)
        {
            _context = context;
        }
        public async Task AddMeasureFemaleAsync(FemaleMeasures female, CancellationToken ct = default)
        {
            if (female == null) throw new ArgumentNullException(nameof(female));

            await _context.FemaleMeasures.AddAsync(female, ct);
        }

        public Task DeleteMeasureFemaleAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<FemaleMeasures> GetFemaleMeasuresByIdAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            return _context.FemaleMeasures.FirstOrDefaultAsync(f => f.UserId == id);
        }

        public Task UpdateMeasuresAsync(FemaleMeasures female)
        {
            throw new NotImplementedException();
        }
    }
}
