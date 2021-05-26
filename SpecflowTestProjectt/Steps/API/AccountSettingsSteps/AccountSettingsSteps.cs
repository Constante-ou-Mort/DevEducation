using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API.AccountSettingsSteps
{
    [Binding]
    class AccountSettingsSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AccountSettingsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send PATCH request client/self/ with (.*) and (.*)")]
        public void WhenSendChangeSelfInfoPATCHRequest(string firstName, string lastName)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientSelfInfoPatch(
                firstName, lastName, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientSelfInfoResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedFirstname, firstName);
            _scenarioContext.Add(Context.ExpectedLastname, firstName);
        }

        [Then(@"Client self information was successfully changed on (.*) in NewBookModels Account")]
        public void ThenSelfInformationSuccessfullyChanged(string selfInformation)
        {
            var user = _scenarioContext.Get<ResponseModel<ChangeSelfInfoResponse>>(Context.ChangedClientSelfInfoResponseModel);
            var selfInfo = "";
            selfInfo += $"{user.Model.FirstName} ";
            selfInfo += $"{user.Model.LastName}";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(selfInformation, selfInfo);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}