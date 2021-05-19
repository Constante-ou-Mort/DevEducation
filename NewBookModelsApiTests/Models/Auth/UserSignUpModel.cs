using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Auth
{
    public class UserSignUpModel
    {
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("first_name")] public string FirstName { get; set; }
        [JsonProperty("last_name")] public string LastName { get; set; }
        [JsonProperty("password")] public string Password { get; set; }
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
    }
}