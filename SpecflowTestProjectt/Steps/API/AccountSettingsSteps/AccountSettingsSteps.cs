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

        [When(@"I send PATCH request client/profile/ with (.*) , (.*) and (.*)")]
        public void WhenSendChangeProfileInfoPATCHRequest(string industry, string locationName, string locationTimezone)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientProfileInfoPatch(
                industry, locationName, locationTimezone, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangeProfileInfoResponse, responseModel);
        }

        [Then(@"Client self information was successfully changed on (.*) in NewBookModels Account")]
        public void ThenClientSelfInformationSuccessfullyChanged(string expectedSelfInformation)
        {
            var user = _scenarioContext.Get<ResponseModel<ChangeSelfInfoResponse>>(Context.ChangedClientSelfInfoResponseModel);
            var selfInfo = "";
            selfInfo += $"{user.Model.FirstName} ";
            selfInfo += $"{user.Model.LastName}";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSelfInformation, selfInfo);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }

        [Then(@"Client profile information was successfully changed on (.*) in NewBookModels Account")]
        public void ThenClientProfileInformationSuccessfullyChanged(string expectedProfileInformation)
        {
            var user = _scenarioContext.Get<ResponseModel<ChangeProfileInfoResponse>>(Context.ChangeProfileInfoResponse);
            var prifileInfo = "";
            prifileInfo += $"{user.Model.Industry}; ";
            prifileInfo += $"{user.Model.LocationName}; ";
            prifileInfo += $"{user.Model.LocationTimezone}";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedProfileInformation, prifileInfo);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}