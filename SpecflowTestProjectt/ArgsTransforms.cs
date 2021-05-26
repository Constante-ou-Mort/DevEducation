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

        [StepArgumentTransformation("current client password")]
        public string GetCurrentClientPassword()
        {
            return Constants.Password;
        }

        [StepArgumentTransformation("new client phone")]
        public string GetNewClientPhone()
        {
            return "3311550022";
        }

        [StepArgumentTransformation("current client first name")]
        public string GetCurrentClientFirstName()
        {
            return Constants.FirstName;
        }

        [StepArgumentTransformation("current client last name")]
        public string GetCurrentClientLastName()
        {
            return Constants.LastName;
        }

        [StepArgumentTransformation("current client industry")]
        public string GetCurrentClientIndustry()
        {
            return Constants.Industry;
        }

        [StepArgumentTransformation("current client location name")]
        public string GetCurrentClientLocationName()
        {
            return Constants.LocationName;
        }

        [StepArgumentTransformation("current client location timezone")]
        public string GetCurrentClientLocationTimezone()
        {
            return Constants.LocationTimezone;
        }

        [StepArgumentTransformation("current company description")]
        public string GetCurrentCompanyDescription()
        {
            return Constants.CompanyDescription;
        }

        [StepArgumentTransformation("current company name")]
        public string GetCurrentCompanyName()
        {
            return Constants.CompanyName;
        }

        [StepArgumentTransformation("current company url")]
        public string GetCurrentCompanyURL()
        {
            return Constants.CompanyURL;
        }
    }
}

