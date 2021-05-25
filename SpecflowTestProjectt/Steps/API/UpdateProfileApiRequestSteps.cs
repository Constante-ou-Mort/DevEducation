using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Features.API
{
    [Binding]
    public class UpdateProfileApiRequestSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public UpdateProfileApiRequestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Change email using Api request POST updating/updating-profile")]
        public void GivenChangeGeneralInformationUsingApiRequestPOSTUpdatingUpdating_Profile(Table table)
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            var changeInfo = ClientRequests.SendRequestChangeClientEmailPost(Constants.Password, table.Rows[0]["email"], createdUser.Model.TokenData.Token);
            _scenarioContext.Add(Constants.User, changeInfo);
        }
    }
}
