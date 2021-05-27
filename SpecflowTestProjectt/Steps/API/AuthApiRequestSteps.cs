using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Features.API
{
    [Binding]
    public class AuthApiRequestSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AuthApiRequestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Authorizate existing client using Api request POST auth/auth-client")]
        public void GivenAuthorizateExistingClientUsingApiRequestPOSTAuthAuth_Client()
        {
            var userData = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.User;
            var user = new Dictionary<string, string>
            {
                { "email", userData.Email },
                {"password", Constants.Password }
            };

            var authrequest = ClientRequests.SendRequestClientSignInPost(user);
            _scenarioContext.Add("Auth", authrequest);
        }
        
        [Then(@"(.*) status code is recieved from the Api reques")]
        public void ThenStatusCodeIsRecievedFromTheApiReques(string status)
        {
            var actualStatus = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>("Auth").Response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, actualStatus);
        }
    }
}
