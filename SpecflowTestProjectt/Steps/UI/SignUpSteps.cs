using System;
using System.Linq;
using NewBook;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignUpPage _singUpPage;
        private readonly IWebDriver _webDriver;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singUpPage = new SignUpPage(_webDriver);
        }

        [Given(@"Sign up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _singUpPage.OpenSignUpPage();
        }

        [When(@"I register with data")]
        public void WhenIRegistrateWithData(Table table)
        {
            _singUpPage.SetName(table.Rows[0]["first_name"]);
            _singUpPage.SetLastName(table.Rows[0]["last_name"]);
            _singUpPage.SetEmail(table.Rows[0]["email"]);
            _singUpPage.SetPassword(table.Rows[0]["password"]);
            _singUpPage.SetPasswordConfirm(table.Rows[0]["password"]);
            _singUpPage.SetPhoneNumber(table.Rows[0]["mobile"]);

            _singUpPage.ClickRegistrationButton();
        }

        [Then(@"Successfully registration in NewBookModels as new client")]
        public void ThenSuccesfullyRegistrationInNewBookModels()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/join/company"));
            Assert.AreEqual(_webDriver.Url, "https://newbookmodels.com/join/company");
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
