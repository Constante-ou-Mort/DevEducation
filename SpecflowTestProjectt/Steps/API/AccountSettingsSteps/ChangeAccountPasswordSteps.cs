using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
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
    public class ChangeAccountPasswordSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeAccountPasswordSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send POST request v1/password/change/ with new password (.*)")]
        public void WhenSendChangePasswordPOSTRequest(string newPassword)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientPasswordPost(
                Constants.Password, newPassword, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientPasswordResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedToken, responseModel.Model.Token);
        }

        [Then(@"Client password was successfully changed in NewBookModels Account")]
        public void ThenClientPasswordChangedWithValidData()
        {
            var user = _scenarioContext.Get<ResponseModel<ChangePasswordResponse>>(Context.ChangedClientPasswordResponseModel);
            var expectedPassword = _scenarioContext.Get<string>(Context.ExpectedToken);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedPassword, user.Model.Token);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}
