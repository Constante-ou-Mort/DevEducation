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
        private readonly CompanySignUpPage _companySignUpPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
        }

        [Then(@"Not registered in NewBookModels as a created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsFalse(_companySignUpPage.IsPageTitleVisible());
        }
    }
}