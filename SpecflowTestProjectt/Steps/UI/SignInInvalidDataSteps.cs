using System.Linq;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInInvalidSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SingInPage _singInPage;

        public SignInInvalidSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singInPage = new SingInPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _singInPage.OpenPage();
        }

        [When(@"I login with data")]
        public void ILoginWithData(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _singInPage.SetEmail(loginModels[0].Email);
            _singInPage.SetPassword(loginModels[0].Password);
            _singInPage.ClickLoginButton(); 
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            _singInPage.ClickLoginButton();
        }

        [Then(@"An error message (.*) is displayed in Login Page")]
        public void ThenUnsuccessfullyLoggedInNewBookModelAsCreatedClient(string message)
        {
            Assert.AreEqual(message, _singInPage.MessageAboutInvalidData());
        }


        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
