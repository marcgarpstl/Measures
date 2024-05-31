using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Measure.Infrastructure.Authentication.Contract
{
    public class SetUserContract
    {
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("given_name")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("family_name")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("connection")]
        public string Connection { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("user_metadata")]
        public dynamic UserMetaData { get; set; }

        public SetUserContract(string email, string firstName, string lastName, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
