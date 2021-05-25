using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class ChangeAccountEmailSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeAccountEmailSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send POST request client/change_email/ with (.*)")]
        public void WhenSendChangeEmailRequestWithValidData(string newEmail)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientEmailPost(
                Constants.Password, newEmail, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientEmailResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedEmail, newEmail);
        }

        [Then(@"Client email was successfully changed in NewBookModels Account")]
        public void ThenClientEmailChangedWithValidData()
        {
            var user = _scenarioContext.Get<ResponseModel<ChangeEmailResponse>>(Context.ChangedClientEmailResponseModel);
            var expectedEmail = _scenarioContext.Get<string>(Context.ExpectedEmail);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEmail, user.Model.Email);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}


