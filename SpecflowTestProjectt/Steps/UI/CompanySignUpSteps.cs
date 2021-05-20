using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly SignUpPage _signUpPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _signUpPage = new SignUpPage(_webDriver);
        }

        [Then(@"Successfully registrated in NewBookModels as new client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_signUpPage.IsPageTitleVisible());
        }
    }
}