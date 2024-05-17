using Measure.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly IUserService _userService;
        private readonly IAutheticationService _autheticationService;

        public TokenHandlerService(IUserService userService, IAutheticationService autheticationService)
        {
            _userService = userService;
            _autheticationService = autheticationService;
        }

        public async Task<string> HandleTokenAsync(string token)
        {
            if(string.IsNullOrEmpty(token)) throw new ArgumentNullException("Token is empty");

            await _autheticationService.AccessTokenToHeader();

            token = token.Replace("Bearer ", string.Empty);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var authId = jwt.Claims.First(claim => claim.Type == "sub").Value;

            if(string.IsNullOrEmpty(authId))
            {
                throw new NullReferenceException("AuthId is null");
            }

            var userId = await _userService.GetByAuthId(authId);

            if(userId == null)
            {
                throw new NotFoundException("User not found");
            }

            return userId.Id.ToString();
        }
    }
}
