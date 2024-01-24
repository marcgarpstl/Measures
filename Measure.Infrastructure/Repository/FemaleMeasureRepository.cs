using Measure.Domain.Entities;
using Measure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Repository
{
    public class FemaleMeasureRepository : IFemaleMeasureRepository
    {
        public Task AddMeasureFemaleAsync(User user, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMeasureFemaleAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetFemaleMeasuresByIdAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMeasuresAsync(FemaleMeasures measures)
        {
            throw new NotImplementedException();
        }
    }
}
