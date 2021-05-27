using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
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
