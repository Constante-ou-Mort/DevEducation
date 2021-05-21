using NUnit;
using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using NUnit.Framework;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly SingInPage _singInPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singInPage = new SingInPage(_webDriver);
        }

        /*[Given(@"Client is authorized")]
        public void GivenClientIsAuthorized()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{Context.User.}');");
            

            _scenarioContext.Add(Context.User, createUser);
        }*/

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _singInPage.OpenPage();
        }

        [When(@"I input email of created client in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _singInPage.SetEmail(user.User.Email);
        }

        [When(@"I input password of created client in password field")]
        public void WhenIInputPasswordOfCreatedClientInEmailField()
        {
            _singInPage.SetPassword(Constants.Password);
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            _singInPage.ClickLoginButton();
        }

        [When(@"I input '(.*)' in email field")]
        public void WhenIInputInvalidEmail(string email)
        {
            _singInPage.SetEmail(email);
        }

        [Then(@"I see error message - '(.*)' on the Sign In page")]
        public void ThenISeeErrorMessageOnSignInPage(string message)
        {
            Assert.AreEqual(message, _singInPage.GetErrorEmailMessage());
        }
    }
}