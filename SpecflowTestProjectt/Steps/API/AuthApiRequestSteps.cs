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

        [When(@"I authorize as an existing client using Api request POST auth/auth-client")]
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
    }
}
