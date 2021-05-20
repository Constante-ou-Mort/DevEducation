using NewBookModelsApiTests.Models.Auth;
using TechTalk.SpecFlow;

namespace SpecflowTestProject
{
    [Binding]
    public class ArgTransforms
    {
        private readonly ScenarioContext _scenarioContext;

        public ArgTransforms(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation("<password>")]
        public string GetDefaultClientPassword()
        {
            return Constants.Password;
        }

        [StepArgumentTransformation("<email>")]
        public string GetCurrentClientEmail()
        {
            return _scenarioContext.Get<ClientAuthModel>(Context.User).User.Email;
        }
    }
}