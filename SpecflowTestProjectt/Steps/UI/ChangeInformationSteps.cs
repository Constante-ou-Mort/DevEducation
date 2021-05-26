using SpecflowTestProject.Pages;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System;
using NUnit.Framework;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    class ChangeInformationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly CompanySignUpPage _companySignUpPage;

        public ChangeInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
        }


    }
}
