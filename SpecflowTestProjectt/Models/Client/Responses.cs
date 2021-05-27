using Newtonsoft.Json;

namespace SpecflowTestProject
{
    public class Responses
    {
        public string Email { get; set; }
    }
    
    public class ChangePhoneNumberResponse
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public class ChangePasswordResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public class ChangeSelfResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payment_method_connected")]
        public bool PaymentMethodConnected { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("client_profile")]
        public ClientProfile ClientProfile { get; set; }

        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        [JsonProperty("avatar")]
        public object Avatar { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}