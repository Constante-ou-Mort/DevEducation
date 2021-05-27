using NewBookModelsApiTests.ApiRequests.Auth;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using static NewBookModelsApiTests.ApiRequests.Client.ClientRequests;

namespace SpecflowTestProject.Features.API
{
    [Binding]
    public class ChangeEmailApiRequest
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeEmailApiRequest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I change email to (.*) via API request")]
        public void ChangeEmailViaAPIRequest(string email, Table table, ScenarioContext scenarioContext)
        {
            var user = _scenarioContext.Get<ChangeGeneralInformation>(Context.User);
            var token = _scenarioContext.Tok
            var changedEmail = ClientRequest.ChangeEmailRequest("Qweqwe123#", expectedEmail, newUser.TokenData.Token);

            Assert.AreEqual(expectedEmail, changedEmail);
        }
    }
}