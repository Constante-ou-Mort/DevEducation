using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignUpPage _singUpPage;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singUpPage = new SignUpPage(webDriver);
        }

        [Given(@"SignUp page is open")]
        public void GivenSignInPageIsOpened()
        {
            _singUpPage.OpenPage();
        }

        [When(@"I filled the (.*) in first name")]
        public void WhenIEnterLoginInLogInField(string firstName)
        {
            
        }
    }
}
