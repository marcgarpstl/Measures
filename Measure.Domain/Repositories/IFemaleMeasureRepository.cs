using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Repositories
{
    public interface IFemaleMeasureRepository
    {
        Task <User> GetFemaleMeasuresByIdAsync(Guid id, CancellationToken ct = default);
        Task AddMeasureFemaleAsync(User user, CancellationToken ct = default);
        Task UpdateMeasuresAsync(FemaleMeasures measures);
        Task DeleteMeasureFemaleAsync(User user);
    }
}
