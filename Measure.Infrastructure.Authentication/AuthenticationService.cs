using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Services;
using Measure.Infrastructure.Authentication.Configuration;
using Measure.Infrastructure.Authentication.Contract;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Text;

namespace Measure.Infrastructure.Authentication
{
    public class AuthenticationService : IAutheticationService
    {
        private const string baseUrl = "https://measures.eu.auth0.com/";
        private readonly string authDefaultConnection = "Username-Password-Authentication";
        private readonly ManagementToken _managementToken;
        private HttpClient _httpClient;

        public AuthenticationService(IOptions<ManagementToken> managementToken, HttpClient httpClient)
        {
            _managementToken = managementToken.Value;
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task AccessTokenToHeader()
        {
            var accessToken = await GetAccessTokenAsync();
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException("Token is null or empty");

            _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");
        }

        public async Task<string> AddAuthUserAsync(SetUserDto setUser)
        {
            if (AccessTokenToHeader() is null) throw new InvalidOperationException("Failed to add access token");

            SetUserContract contract = new SetUserContract(setUser.Email, setUser.FirstName, setUser.LastName, setUser.Password);

            const string url = "api/v2/user";

            if (String.IsNullOrEmpty(contract.Connection))
            {
                contract.Connection = authDefaultConnection;
            }
            contract.UserMetaData = new
            {
                username = setUser.UserName
            };

            var response = await _httpClient.PostAsync(url, JsonToString(contract));
            var  content = await response.Content.ReadAsStringAsync();
            dynamic responseContent = JsonConvert.DeserializeObject<dynamic>(content);
            return responseContent.user_id;
        }

        public async Task DeleteAuthUserAsync(string authId)
        {
            var url = $"api/v2/users/{authId}";
            await AccessTokenToHeader();
            await _httpClient.DeleteAsync(url);
        }

        public StringContent JsonToString(object input)
        {
            if(input  == null) throw new ArgumentNullException("input");

            var json = JsonConvert.SerializeObject(input);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            if (stringContent is null) throw new ArgumentNullException("StringContent is empty");
            return stringContent;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            const string url = "oauth/token";
            var response = await _httpClient.PostAsync(url, JsonToString(_managementToken));
            var content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
            if (response.IsSuccessStatusCode)
            {
                return result.access_token;
            }
            else throw new InvalidOperationException($"Error fetching access token: {result.error_description}");
        }
    }
}
