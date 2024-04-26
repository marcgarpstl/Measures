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
        Task <FemaleMeasures> GetFemaleMeasuresByIdAsync(Guid id, CancellationToken ct = default);
        Task UpdateMeasureFemaleAsync(FemaleMeasures female, CancellationToken ct = default);
        Task DeleteMeasureFemaleAsync(User user);
    }
}
