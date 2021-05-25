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

        [Given(@"Change phone to (.*) using Api request POST updating/updating-profile")]
        public void GivenChangePhoneUsingApiRequestPOSTUpdatingUpdating_Profile(string phone, Table table)
        {
            var user = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.TokenData.Token;

            var newPhone = ClientRequests.SendRequestChangePhoneNumberPost(Constants.Password, table.Rows[0]["phone_number"], user);

            _scenarioContext[Constants.User] = newPhone;
        }
    }
}
