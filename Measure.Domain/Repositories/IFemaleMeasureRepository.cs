﻿using Measure.Domain.Entities;
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
        Task AddMeasureFemaleAsync(FemaleMeasures female, CancellationToken ct = default);
        Task UpdateMeasuresAsync(FemaleMeasures female);
        Task DeleteMeasureFemaleAsync(User user);
    }
}