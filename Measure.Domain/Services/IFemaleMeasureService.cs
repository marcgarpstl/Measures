using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public interface IFemaleMeasureService
    {
        Task<ReadFemaleMeasuresDto> GetFemaleMeasureAsync(Guid id, CancellationToken ct = default);
        Task AddFemaleMeasureAsync(Guid id, SetFemaleMeasuresDto femaleMeasures, CancellationToken ct = default);
        Task DeleteFemaleMeasureAsync(Guid id, CancellationToken ct = default);
    }
}
