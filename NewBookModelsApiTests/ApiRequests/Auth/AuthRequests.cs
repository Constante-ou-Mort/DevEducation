using System;
using System.Collections.Generic;
using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using RestSharp;

namespace NewBookModelsApiTests.ApiRequests.Auth
{
    public static class AuthRequests
    {
        public static ClientAuthModel SendRequestClientSignUpPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

        public static ClientAuthModel SendRequestClientSignInPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authrizedUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return authrizedUser;
        }

        public static ClientAuthModel SendRequestClientSignInPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authrizedUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return authrizedUser;
        }
    }
}