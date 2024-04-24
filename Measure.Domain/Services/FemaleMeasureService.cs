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
        private readonly IUserRepository _userRepository;
        public FemaleMeasureService(IFemaleMeasureRepository repository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _femaleRepository = repository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task AddFemaleMeasureAsync(Guid id, SetFemaleMeasuresDto femaleMeasures, CancellationToken ct = default)
        {
            if (femaleMeasures == null) throw new ArgumentNullException(nameof(femaleMeasures));

            var user = await _userRepository.GetUserByGuidAsync(id);

            var female = await _femaleRepository.GetFemaleMeasuresByIdAsync(id);

            user.Female = female;

            user.Female = femaleMeasures.ToFemaleMeasures();

            await _femaleRepository.AddMeasureFemaleAsync(user.Female, ct);
            await _unitOfWork.SaveChangesAsync(ct);

        }

        public Task<SetFemaleMeasuresDto> DeleteFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadFemaleMeasuresDto> GetFemaleMeasureAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            var userFemale = await _femaleRepository.GetFemaleMeasuresByIdAsync(id);

            if (userFemale == null) throw new ArgumentException(nameof(userFemale));

            else if (ct.IsCancellationRequested) throw new InvalidOperationException();

            return userFemale.ToFemaleDto();
        }

        Task IFemaleMeasureService.DeleteFemaleMeasureAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
