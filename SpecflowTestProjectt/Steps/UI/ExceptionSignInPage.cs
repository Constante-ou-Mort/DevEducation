using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    public class ExceptionSignInPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly SingInPage _signInPage;

        public ExceptionSignInPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _signInPage = new SingInPage(_webDriver);
        }

        [Then(@"exception message (.*) is displayed")]
        public void ThenExceptionMessageIsDisplayed(string message)
        {
            Assert.AreEqual(message, _signInPage.GetExceptionInvalidData());
        }
    }
}
