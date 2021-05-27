using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Features.API
{
    [Binding]
    public class ChangePhoneNumberApiRequestSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangePhoneNumberApiRequestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I change phone to (.*) using Api request POST client/change_phone")]
        public void GivenChangePhoneUsingApiRequestPOSTUpdatingUpdating_Profile(string phone, Table table)
        {
            var user = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.TokenData.Token;

            var newPhone = ClientRequests.SendRequestChangePhoneNumberPost(Constants.Password, phone, user);

            _scenarioContext[Constants.User] = newPhone;
        }
    }
}
