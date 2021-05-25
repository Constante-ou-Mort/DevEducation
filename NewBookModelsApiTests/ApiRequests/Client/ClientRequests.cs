using System.Collections.Generic;
using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using RestSharp;
using static NewBookModelsApiTests.ApiRequests.Auth.AuthRequests;

namespace NewBookModelsApiTests.ApiRequests.Client
{
    public static class ClientRequests
    {
        public static ResponseModel<ClientAuthModel> SendRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeEmailResponse = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = changeEmailResponse, Response = response };
        }

        public static ResponseModel<ClientAuthModel> SendRequestChangePhoneNumberPost(string password, string phoneNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "password", password },
                 { "phone_number", phoneNumber }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = changePhoneResponse, Response = response };
        }

        public static ResponseModel<ClientAuthModel> SendRequestClientSignInPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = authUser, Response = response };
        }
    }
}