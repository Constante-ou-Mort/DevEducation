using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    public class ChangePhoneNumberResponse
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}

