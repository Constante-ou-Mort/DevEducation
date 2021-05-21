using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestProject.Steps.API.Models
{
    public class ClientAuthModel
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("token_data")]
        public TokenData TokenData { get; set; }
    }
}
}
