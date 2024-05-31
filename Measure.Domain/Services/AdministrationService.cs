using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IUserService _userService;
        private readonly IAutheticationService _autheticationService;

        public AdministrationService(IUserService userService, IAutheticationService autheticationService)
        {
            _userService = userService;
            _autheticationService = autheticationService;
        }

        public async Task AddAuthUser(SetUserDto user, CancellationToken ct = default)
        {
            if(user == null) throw new ArgumentNullException(nameof(user));

            var authId = await _autheticationService.AddAuthUserAsync(user);
            user.ToSetUser(authId);
            await _userService.AddUserAsync(user);
        }

        public async Task DeleteAuthUser(string authId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
