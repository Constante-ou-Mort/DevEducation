using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SpecflowTestProject.Steps.API.Models;
using NUnit.Framework;

namespace SpecflowTestProject.Steps
{
    [Binding]
    class SignInAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        public SignInAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public static string SendRequestSignInPost(string email, string password)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);
            var newSignInModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(newSignInModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var token = JsonConvert.DeserializeObject<ResponseSignInModel>(response.Content).TokenData.Token;

            return token;
        }

        [When(@"I send POST request auth/signin/ with valid data")]
        public void WhenISendSignInRequest()
        {
            var token = SendRequestSignInPost("its26202103221003@gmail.com", "123qweQWE!1");
            _scenarioContext.Add("Token", token);
        }

        [Then(@"User successfully logging in")]
        public void GivenUserIsAuthorizated()
        {
            var actualResult = _scenarioContext.Get<string>("Token");
            Assert.IsNotNull(actualResult);
        }

    }
}
