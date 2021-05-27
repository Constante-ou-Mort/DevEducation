using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RegistrationPage _registrationPage;
        private IWebDriver _webDriver;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _registrationPage = new RegistrationPage(webDriver);
        }
        [Given(@"Sign Up page is open")]
        public void GivenSignUpPageIsOpened()
        {
            _registrationPage.OpenPage();
        }
        [When(@"I filled the (.*) in first name")]
        public void WhenIFiledTheInFirstName(string firstName)
        {
            _registrationPage.SetFirstName(firstName);
        }
        [When(@"I filled the (.*) in last name")]
        public void WhenIFiledTheInLastName(string lastName)
        {
            _registrationPage.SetLastName(lastName);
        }
        [When(@"I filled the (.*) in email")]
        public void WhenIFiledTheInEmail(string email)
        {
            _registrationPage.SetEmail(email);
        }
        [When(@"I filled the (.*) in password")]
        public void WhenIFiledTheInPassword(string password)
        {
            _registrationPage.SetPassword(password);
        }
        [When(@"I confirm (.*)")]
        public void WhenICnfirm(string password)
        {
            _registrationPage.SetConfirmPassword(password);
        }
        [When(@"I filled the (.*) in number")]
        public void WhenIFiledTheInNamber(string number)
        {
            _registrationPage.SetMobile(number);
        }

        [When(@"I click Next button")]
        public void WhenIClickNextButton()
        {
            _registrationPage.ClickLoginButton();
        }

        [Then(@"Succesfully registration in NewBookModels")]
        public void ThenSuccesfullyRegistrationInNewBookModels()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/join/company"));
            Assert.AreEqual(_webDriver.Url, "https://newbookmodels.com/join/company");
        }
    }
}
