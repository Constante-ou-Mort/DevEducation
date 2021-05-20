using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTestProject
{
    [Binding]
    class ArgsTransforms
    {
        private readonly ScenarioContext _scenarioContext;

        public ArgsTransforms(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation ("new client email")]
        public string GetNewClientEmail()
        {
            return $"Jonson{DateTime.Now:ddyyyymmHHmmssffff}@gmail.com";
        }
    }
}

