using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

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

        [When(@"I change email to (.*) using Api request POST client/change_email")]
        public void GivenChangeGeneralInformationUsingApiRequestPOSTClientChange_Email(string email, Table table)
        {
            var user = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.TokenData.Token;
            email = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";

            var changeInfo = ClientRequests.SendRequestChangeClientEmailPost(Constants.Password, email, user);
            _scenarioContext[Constants.User] = changeInfo;
        }
    }
}
