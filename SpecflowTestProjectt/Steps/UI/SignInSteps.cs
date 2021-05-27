using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignInPage _signInPage;
        private readonly SignUpPage _signUpPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _signInPage = new SignInPage(webDriver);
            _signUpPage = new SignUpPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _signInPage.OpenPage();
        }

        [When(@"I login with email (.*) and password (.*)")]
        public void ILoginWithData(string email, string password)
        {
            email = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.User.Email;
            _signInPage.SetEmail(email);
            _signInPage.SetPassword(Constants.Password);
            _signInPage.ClickLoginButton();
        }

        [When(@"I login with invalid email (.*) and password (.*)")]
        public void WhenILoginWithInvalidEmailAndPassword(string email, string password)
        {
            _signInPage.SetEmail(email);
            _signInPage.SetPassword(password);
            _signInPage.ClickLoginButton();
        }


        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelsAsCreatedClient()
        {
            Assert.IsTrue(_signUpPage.IsPageTitleVisible());
        }
    }
}