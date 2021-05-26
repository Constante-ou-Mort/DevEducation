using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    public class ChangeProfileInfoResponse
    {
        [JsonProperty("industry")]
        public string Industry { get; set; }
        [JsonProperty("location_name")]
        public string LocationName { get; set; }
        [JsonProperty("location_timezone")]
        public string LocationTimezone { get; set; }
    }
}
