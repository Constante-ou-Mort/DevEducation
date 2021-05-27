using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class ApiThenSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ApiThenSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"(.*) status code is recieved from the Api request")]
        public void ThenStatusCodeIsRecievedFromTheApiRequest(string status)
        {
            var actualStatus = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Response.StatusCode;
            Assert.AreEqual(status, actualStatus.ToString());
        }

        [Then(@"message (.*) is recieved from the Api request")]
        public void MessageIsRecievedFromTheApiRequest(string status)
        {
            var actualStatus = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Response.StatusDescription;
            Assert.AreEqual(status, actualStatus);
        }
    }
}
