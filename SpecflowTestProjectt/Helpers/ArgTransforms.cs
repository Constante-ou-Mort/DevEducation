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

        [StepArgumentTransformation("uniqEmail")]
        public string GetRegistrationEmail()
        {
            return $"{DateTime.Now:yyyyMMddTHHmmss}@gmail.com";
        }
    }
}