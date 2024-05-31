using Measure.Domain.Services;
using Measure.Infrastructure.Authentication.Configuration;

namespace Measure.Infrastructure.Authentication
{
    public class AuthenticationService : IAutheticationService
    {
        private const string baseUrl = "";
        private readonly string authDefaultConnection = "Username-Password-Authentication";
        private readonly ManagementToken _managementToken;

        public Task AccessTokenToHeader()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAccessTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
