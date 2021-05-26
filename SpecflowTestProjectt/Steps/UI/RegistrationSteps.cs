using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly IWebDriver _webDriver;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
             _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singUpPage = new SignUpPage(_webDriver);
           
        }

        [Given(@"SignUp page is open")]
        public void GivenSignInPageIsOpened()
        {
            _singUpPage.OpenPage();
        }

        [When(@"I fill the (.*) in first name")]
        public void WhenIFillTheFirstName(string firstName)
        {
            _singUpPage.SetFirstName(firstName);
        }

        [When(@"I fill the (.*) in last name")]
        public void WhenIFillTheLastName(string lastName)
        {
            _singUpPage.SetLastName(lastName);
        }

        [When(@"I fill the (.*) in email")]
        public void WhenIFillTheEmail(string email)
        {
            _singUpPage.SetEmail(email);
        }

        [When(@"I fill the (.*) in password")]
        public void WhenIFillThePassword(string password)
        {
            _singUpPage.SetPassword(password);
        }

        [When(@"I confirm (.*)")]
        public void WhenIConfirmPassword(string password)
        {
            _singUpPage.SetConfirmPassword(password);
        }

        [When(@"I fill the (.*) in number")]
        public void WhenIFillTheNumber(string number)
        {
            _singUpPage.SetPhone(number);
        }

        [When(@"I click Next button")]
        public void WhenIClickNextButton()
        {
            _singUpPage.ClickNextButton();
        }

        [Then(@"Account is created")]
        public void ThenAccountIsCreated()
        {
            var actualUrl = _singUpPage.GetUrl();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlMatches("https://newbookmodels.com/join/company"));
            Assert.AreEqual("https://newbookmodels.com/join/company", actualUrl);
        }

        [Then(@"Account is not created")]
        public void ThenAccountIsNotCreated()
        {
            var actualUrl = _singUpPage.GetUrl();
            Assert.AreEqual("https://newbookmodels.com/join", actualUrl);
        }
    }
}
