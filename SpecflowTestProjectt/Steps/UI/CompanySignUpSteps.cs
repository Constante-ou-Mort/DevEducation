﻿using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using SeleniumTests.POM.SignUp;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly CompanySignUpPage _companySignUpPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
        }

        [Then(@"I successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }

        [Then(@"New client is successfully registrated in NewBookModels")]
        public void ThenNewClientSuccessfullyRegisteredInNewBookModels()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }
    }
}