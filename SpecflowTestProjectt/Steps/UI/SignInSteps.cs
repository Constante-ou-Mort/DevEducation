using System.Linq;
using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SingInPage _singInPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _singInPage = new SingInPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _singInPage.OpenPage();
        }

        [When(@"I login with email (.*) and password (.*)")]
        public void ILoginWithData(Table table, string email, string password)
        {
            _singInPage.SetEmail(email);
            _singInPage.SetPassword(password);
            _singInPage.ClickLoginButton();
        }
    }
}