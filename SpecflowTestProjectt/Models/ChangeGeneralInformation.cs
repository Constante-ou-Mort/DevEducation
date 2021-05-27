using Newtonsoft.Json;

namespace ModelBookAPITests
{
    public class ChangeGeneralInformation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("facebook_followers")]
        public object FacebookFollowers { get; set; }

        [JsonProperty("instagram_followers")]
        public object InstagramFollowers { get; set; }

        [JsonProperty("has_invite")]
        public bool HasInvite { get; set; }

        [JsonProperty("company_website")]
        public object CompanyWebsite { get; set; }

        [JsonProperty("company_name")]
        public object CompanyName { get; set; }

        [JsonProperty("company_description")]
        public object CompanyDescription { get; set; }

        [JsonProperty("referral")]
        public object Referral { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("is_sms_enabled")]
        public bool IsSmsEnabled { get; set; }

        [JsonProperty("location_latitude")]
        public double LocationLatitude { get; set; }

        [JsonProperty("location_longitude")]
        public double LocationLongitude { get; set; }

        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        [JsonProperty("location_city_name")]
        public string LocationCityName { get; set; }

        [JsonProperty("location_admin1_code")]
        public string LocationAdmin1Code { get; set; }

        [JsonProperty("location_timezone")]
        public string LocationTimezone { get; set; }

        [JsonProperty("company_address")]
        public string CompanyAddress { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("twitter_followers")]
        public object TwitterFollowers { get; set; }

        [JsonProperty("youtube_followers")]
        public object YoutubeFollowers { get; set; }
    }
}