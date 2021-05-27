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
    public class ChangeAccountFirstNameAndLastNameSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ChangeAccountFirstNameAndLastNameSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send PATCH request client change_first_name change_last_name with new first name (,*), with new last name (,*)")]
        public void WhenISendChangeFirstNameAndLastNameRequestWithValidData(string firstName, string lastName)
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var responseModel = ClientRequests.SendRequestChangeFirstNammeLastNamePatch(
               firstName, lastName, user.TokenData.Token);

            _scenarioContext.Add(Context.ChangedClientFirstNameAndLastNameResponseModel, responseModel);
            _scenarioContext.Add(Context.ExpectedFirstNameAndLastName, firstName);
            _scenarioContext.Add(Context.ExpectedFirstNameAndLastName, lastName);
        }

        [Then(@"Client first name and last name successfully changed in NewBookModels Account")]
        public void ThenClientFirstNameAndLastNameChangedWithValidData()
        {
            var user = _scenarioContext.Get<ClientRequests.ResponseModel<ChangedFirstNameLastName>>(Context.ChangedClientFirstNameAndLastNameResponseModel);
            var expectedFirstNameAndLastName = _scenarioContext.Get<string>(Context.ExpectedFirstNameAndLastName);

            Assert.AreEqual(HttpStatusCode.OK, user.Response.StatusCode);
            
        }
    }
}
