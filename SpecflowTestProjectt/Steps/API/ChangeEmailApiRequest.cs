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

        [Given(@"Change email to (.*) using Api request POST updating/updating-profile")]
        public void GivenChangeGeneralInformationUsingApiRequestPOSTUpdatingUpdating_Profile(string email, Table table)
        {
            var user = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.TokenData.Token; 

            var changeInfo = ClientRequests.SendRequestChangeClientEmailPost(Constants.Password, table.Rows[0]["email"], user);
            _scenarioContext[Constants.User] = changeInfo;
        }
    }
}
