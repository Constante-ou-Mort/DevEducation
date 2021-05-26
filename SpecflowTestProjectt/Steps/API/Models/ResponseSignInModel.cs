using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestProject.Steps.API.Models
{
    class ResponseSignInModel
    {
        [JsonProperty("token_data")]
        public TokenData TokenData { get; set; }
    }
}
