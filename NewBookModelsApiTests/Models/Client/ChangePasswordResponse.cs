using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    public class ChangePasswordResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
