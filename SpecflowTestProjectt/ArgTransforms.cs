using NewBookModelsApiTests.Models.Auth;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTestProject
{
    [Binding]
    public class ArgTransforms
    {
        private readonly ScenarioContext _scenarioContext;
        private string usedUniqueEmail;

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

        [StepArgumentTransformation("uniqueEmail")]
        public string GetUniqueEmail()
        {
            usedUniqueEmail = $"tribianidylan{DateTime.Now:yyyyMMddhhmmss}@gmail.com";
            return usedUniqueEmail;
        }

        [StepArgumentTransformation("usedUniqueEmail")]
        public string GetUsedUniqueEmail()
        {
            return usedUniqueEmail;
        }
    }
}