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

        [StepArgumentTransformation("unique_email")]
        public string GetDefaultClientPassword()
        {
            return Constants.Email;
        }
    }
}