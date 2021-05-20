using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    class ChangeAccountEmailSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeAccountEmailSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"Authorized as created client I send request for changing email with with valid data in NewBookModels Account")]
        public void WhenSendChangeEmailRequestWithValidData()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var expectedEmail = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
            var responseModel = ClientRequests.SendRequestChangeClientEmailPost(
                Constants.Password, expectedEmail, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientEmailResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedEmail, expectedEmail);
        }

        [Then(@"Client email was successfully changed with valid data in NewBookModels Account")]
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


