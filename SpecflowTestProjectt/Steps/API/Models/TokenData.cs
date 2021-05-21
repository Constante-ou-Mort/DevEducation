using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestProject.Steps.API.Models
{
    public class TokenData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("token_refresh_expires")]
        public DateTime TokenRefreshExpires { get; set; }

        [JsonProperty("firebase_token")]
        public string FirebaseToken { get; set; }

        [JsonProperty("firebase_token_expires")]
        public DateTime FirebaseTokenExpires { get; set; }
    }
}
