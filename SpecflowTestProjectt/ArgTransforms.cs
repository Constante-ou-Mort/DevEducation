using NewBookModelsApiTests.Models.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;

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

        [StepArgumentTransformation("new client email")]
        public string GetNewClientEmail()
        {
            return $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com";
        }
    }
}