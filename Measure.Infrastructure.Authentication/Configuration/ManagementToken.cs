using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Measure.Infrastructure.Authentication.Configuration
{
    public class ManagementToken
    {
        [JsonProperty("client_id")]
        public string ClientId { get; init; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; init; }

        [JsonProperty("audience")]
        public string Audience { get; init; }

        [JsonProperty("grant_type")]
        public string GrantType { get; init; } = "client_credentials";

    }
}
