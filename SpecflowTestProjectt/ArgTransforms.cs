using NewBookModelsApiTests.Models.Auth;
using System;
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

        [StepArgumentTransformation("default client password")]
        public string GetDefaultClientPassword()
        {
            return Constants.Password;
        }

        [StepArgumentTransformation("current client email")]
        public string GetCurrentClientEmail()
        {
            return _scenarioContext.Get<ClientAuthModel>(Context.User).User.Email;
        }

        [StepArgumentTransformation("unique email")]
        public string GetUniqueEmailPassword()
        {
            return $"tribianidylan{DateTime.Now:yyyyMMddhhmmss}@gmail.com";
        }
    }
}