using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public interface IUserService
    {
        Task<ReadUserDto> GetById(Guid id, CancellationToken ct = default);
        Task AddUserAsync(SetUserDto user, CancellationToken ct = default);
        Task ChangeEmail(Guid id, string email, CancellationToken ct = default);
        Task ChangePassword(Guid id, string password, CancellationToken ct = default);
        Task DeleteUser(Guid id, CancellationToken ct = default);
    }
}
