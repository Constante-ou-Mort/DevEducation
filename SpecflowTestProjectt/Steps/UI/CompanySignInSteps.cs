using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly CompanySignUpPage _companySignUpPage;
        private readonly SingInPage _signInPage;

        public CompanySignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _signInPage = new SingInPage(_webDriver);
        }

        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }

        [Then(@"exception message <message> is displayed")]
        public void ThenExceptionMessageIsDisplayed()
        {
            Assert.AreEqual("Invalid Email", _signInPage.GetExceptionInvalidData());
        }
    }
}