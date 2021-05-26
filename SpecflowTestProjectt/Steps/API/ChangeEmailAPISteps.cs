using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class ChangeEmailAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        public ChangeEmailAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public static ResponseModel<ClientAuthModel> CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>
                {
                    { "email" , $"its{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                    { "first_name" , "Petter" },
                    { "last_name" ,"Parker" },
                    { "password" ,"123qweQWE!"},
                    { "phone_number" , "3453453454"}
                };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = createdUser, Response = response };
        }

        public static string SendRequestChangeClientEmailPost(string password, string newEmail, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", newEmail },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return changedEmailResponse.Email;
        }

        [Given(@"User is authorizated")]
        public void GivenUserIsAuthorizated()
        {
            var user = CreateUserViaApi();
            _scenarioContext.Add("Response", user);
        }

        [When(@"I send POST request client/change_email/ with new email")]
        public void WhenISendValidChangeEmailReques()
        {
            var responseEmailModel = SendRequestChangeClientEmailPost("123qweQWE!", $"new{ DateTime.Now:ddyyyymmHHssmm}@gmail.com", _scenarioContext.Get<ResponseModel<ClientAuthModel>>("Response").Model.TokenData.Token);
            _scenarioContext.Add("Email Response", responseEmailModel);
        }

        [Then(@"User`s email changed")]
        public void ThenUsersEmailChanging()
        {
            var actualResult = _scenarioContext.Get<string>("Email Response");

            Assert.AreEqual("new", actualResult.Substring(0,3));
        }
    }
}
