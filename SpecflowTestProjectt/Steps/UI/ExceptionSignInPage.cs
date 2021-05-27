using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class ExceptionSignInPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly SignInPage _signInPage;

        public ExceptionSignInPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _signInPage = new SignInPage(_webDriver);
        }

        [Then(@"exception message (.*) is displayed on sign in page")]
        public void ThenExceptionMessageIsDisplayedOnSignInPage(string message)
        {
            Assert.AreEqual(message, _signInPage.GetExceptionInvalidData());
        }

    }
}
