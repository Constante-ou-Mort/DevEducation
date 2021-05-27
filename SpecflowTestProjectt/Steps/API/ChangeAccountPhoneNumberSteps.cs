using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;
using static NewBookModelsApiTests.ApiRequests.Client.ClientRequests;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class ChangeAccountPhoneNumberSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeAccountPhoneNumberSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send POST request client change_phone with new phone '(.*)'")]
        public void WhenSendChangePhoneNumberRequestWithValidData(string newPhoneNumber)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeClientPhoneNumberPost(
                Constants.Password, newPhoneNumber, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientPhoneNumberlResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedPhoneNumber, newPhoneNumber);
        }

        [Then(@"Successfully changed  phone number in NewBookModels Account")]
        public void ThenClientPhomeNumberChangedWithValidData()
        {
            var user = _scenarioContext.Get<ClientRequests.ResponseModel<ChangePhoneNumberResponse>>(Context.ChangedClientPhoneNumberlResponseModel);
            var expectedPhoneNumber = _scenarioContext.Get<string>(Context.ExpectedPhoneNumber);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedPhoneNumber, user.Model.PhoneNumber);
                Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            });
        }
    }
}
