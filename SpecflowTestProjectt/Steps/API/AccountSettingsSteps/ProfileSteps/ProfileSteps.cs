using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API.AccountSettingsSteps.ProfileSteps
{
    [Binding]
    public class ProfileSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ProfileSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send PATCH request company client/profile/ with (.*) , (.*) and (.*)")]
        public void WhenSendCompanyInfoPATCHRequest(string expectedCompanyDescription, string expectedCompanyName, string expectedCompanyURL)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientProfileCompanyInfoPatch(
                expectedCompanyDescription, expectedCompanyName, expectedCompanyURL, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangeCompanyInfoResponse, responseModel);
        }

        [Then(@"Client profile company info was successfully changed on (.*) in NewBookModels Account")]
        public void ThenCompanyInformationSuccessfullyChanged(string expectedCompanyInformation)
        {
            var user = _scenarioContext.Get<ResponseModel<ChangeCompanyInfoResponse>>(Context.ChangeCompanyInfoResponse);
            var companyInfo = "";
            companyInfo += $"{user.Model.CompanyDescription}; ";
            companyInfo += $"{user.Model.CompanyName}; ";
            companyInfo += $"{user.Model.CompanyWebsite}";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCompanyInformation, companyInfo);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}
