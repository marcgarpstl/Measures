using Measure.Domain.DTOs.WriteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public interface IAdministrationService
    {
        Task AddAuthUser(SetUserDto user, CancellationToken ct = default);
        Task DeleteAuthUser(string authId, CancellationToken ct = default);
    }
}
