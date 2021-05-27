using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class RegistrationAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        public RegistrationAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send POST request registration client with valid data")]
        public void WhenISendPOSTRequestRegistrationValidData()
        {
            var user = _scenarioContext.Get<ResponseModel<ClientAuthModel>>(Context.User);
            var responseSignUpModel = ClientRequests.CreateUserViaApi();
  
            _scenarioContext.Add("Response", responseSignUpModel);
        }

        [Then(@"Succesfully registration client in NewBookModels")]
        public void ThenSuccesfullyRegistrationClient()
        {
            var actualResult = _scenarioContext.Get<ResponseModel<ClientAuthModel>>("Response");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, actualResult.Response.StatusCode);
                Assert.AreEqual("Will", actualResult.Model.User.FirstName);
                Assert.AreEqual("Smith", actualResult.Model.User.LastName);
            });
        }
    }
}
