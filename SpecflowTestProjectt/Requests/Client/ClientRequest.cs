using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace SpecflowTestProject
{
    public class ClientRequest
    {
        public static string ChangeEmailRequest(string password, string newEmail, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", newEmail },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeEmailResponse = JsonConvert.DeserializeObject<Responses>(response.Content);

            return changeEmailResponse.Email;
        }

        public static HttpStatusCode ChangePassword(string oldPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", oldPassword},
                { "new_password", newPassword},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return response.StatusCode;
        }

        public static string ChangePhoneNumber(string password, string newNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
                    {
                        {"password",password},
                        {"phone_number",newNumber}
                    };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ChangePhoneNumberResponse>(response.Content);

            return changePhoneResponse.PhoneNumber;
        }

        public static string ChangeName(string firstName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newNameModel = new Dictionary<string, string>
            {
                { "first_name", firstName},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeNameResponse = JsonConvert.DeserializeObject<ChangeSelfResponse>(response.Content);

            return changeNameResponse.FirstName;
        }

        public static string ChangeLastName(string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newLastNameModel = new Dictionary<string, string>
            {
                { "last_name", lastName},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newLastNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeLastNameResponse = JsonConvert.DeserializeObject<ChangeSelfResponse>(response.Content);

            return changeLastNameResponse.LastName;
        }

        public static string ChangeCompanyLocation(string locationCode, string locationCity, string locationLatitude, string locationLongitude, string locationName, string locationTime, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newCompanyLocationsModel = new Dictionary<string, string>
            {                         
                {"location_admin1_code", locationCode},
                {"location_city_name", locationCity},
                {"location_latitude", locationLatitude},
                {"location_longitude", locationLongitude},
                {"location_name", locationName},
                {"location_timezone", locationTime},
        };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newCompanyLocationsModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeCompanyLocationResponse = JsonConvert.DeserializeObject<ChangeGeneralInformation>(response.Content);

            return changeCompanyLocationResponse.CompanyAddress;
        }

        public static string ChangeIndustry(string industry, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newIndustryModel = new Dictionary<string, string>
            {
                { "industry", industry},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newIndustryModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeIndustryResponse = JsonConvert.DeserializeObject<ChangeGeneralInformation>(response.Content);

            return changeIndustryResponse.Industry;
        }
    }
}