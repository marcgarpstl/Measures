using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using Measure.Domain.Extensions;
using Measure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public class FemaleMeasureService : IFemaleMeasureService
    {
        private readonly IFemaleMeasureRepository _femaleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FemaleMeasureService(IFemaleMeasureRepository repository, IUnitOfWork unitOfWork)
        {
            _femaleRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddFemaleMeasureAsync(Guid id, SetFemaleMeasuresDto femaleMeasures, CancellationToken ct = default)
        {
            if (femaleMeasures == null) throw new ArgumentNullException(nameof(femaleMeasures));

            FemaleMeasures addMeasures = femaleMeasures.ToFemaleMeasures();
            await _femaleRepository.AddMeasureFemaleAsync(addMeasures, ct);
        }

        public Task DeleteFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<ReadFemaleMeasuresDto> GetFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
