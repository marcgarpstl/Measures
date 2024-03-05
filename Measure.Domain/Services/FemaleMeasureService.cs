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

        public async Task<FemaleMeasures> AddFemaleMeasureAsync(SetFemaleMeasuresDto femaleMeasures, CancellationToken ct = default)
        {
            if (femaleMeasures == null) throw new ArgumentNullException(nameof(femaleMeasures));

            FemaleMeasures addMeasures = femaleMeasures.ToFemaleMeasures();

            await _femaleRepository.AddMeasureFemaleAsync(addMeasures, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return addMeasures;
        }

        public Task DeleteFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadFemaleMeasuresDto> GetFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            var userFemale = await _femaleRepository.GetFemaleMeasuresByIdAsync(id);

            if (userFemale == null) throw new ArgumentException(nameof(userFemale));

            else if (ct.IsCancellationRequested) throw new InvalidOperationException();

            return userFemale.Female.ToFemaleDto();
        }
    }
}
