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
        public void ThenStatusCodeIsRecievedFromTheApiRequest(string status, Table table)
        {
            var actualStatus = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Response.StatusCode;
            Assert.AreEqual(table.Rows[0]["status_code"], actualStatus.ToString());
        }

        [Then(@"message (.*) is recieved from the Api request")]
        public void MessageIsRecievedFromTheApiRequest(string status, Table table)
        {
            var actualStatus = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Response.StatusDescription;
            Assert.AreEqual(table.Rows[0]["message"], actualStatus);
        }
    }
}
