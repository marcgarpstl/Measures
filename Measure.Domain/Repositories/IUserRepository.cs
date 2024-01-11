﻿using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user, CancellationToken ct = default);
    }
}
