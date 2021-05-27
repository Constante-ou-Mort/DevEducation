using System;
using System.Collections.Generic;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using Newtonsoft.Json;
using RestSharp;

namespace NewBookModelsApiTests.ApiRequests.Client
{
    public static class ClientRequests
    {
        public static ResponseModel<ChangeEmailResponse> SendRequestChangeClientEmailPost(string password, string email, string token)
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
            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return new ResponseModel<ChangeEmailResponse> { Model = changeEmailResponse, Response = response };
        }
    
        public static ResponseModel<ChangePhoneNumberResponse> SendRequestChangeClientPhoneNumberPost(string password, string phone, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
               {
                  { "password", password },
                  { "phone_number", phone },
               };
        
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;
        
            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ChangePhoneNumberResponse>(response.Content);
        
            return new ResponseModel<ChangePhoneNumberResponse> { Model = changePhoneResponse, Response = response };
        }
        
        public class ResponseModel<T>
        {
            public T Model { get; set; }
            public IRestResponse Response { get; set; }  
        }

        public static ResponseModel<ChangedFirstNameLastName> SendRequestChangeFirstNammeLastNamePatch(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newPrimaryAccountHolderNameModel = new Dictionary<string, string>
            {
               {"first_name", firstName },
               {"last_name", lastName },
            };     

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPrimaryAccountHolderNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var newGeneralInfo = JsonConvert.DeserializeObject<ChangedFirstNameLastName>(response.Content);

            return new ResponseModel<ChangedFirstNameLastName> { Model = newGeneralInfo, Response = response };
        }

        public static ResponseModel<ClientAuthModel> CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>
                {
                    { "email" , $"its{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                    { "first_name" , "Will" },
                    { "last_name" ,"Smith" },
                    { "password" ,"123qweQWE!"},
                    { "phone_number" , "444444444"}
                };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = createdUser, Response = response };
        }

    }
}