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

        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }
        
        [Then(@"Error massage with text '(.*)' for (email|password) field")]
        public void ThenTheErrorMassageIsShowed()
        {
            if (_companySignUpPage.IsEmailErrorDisplayd(out string errorMessage))
            {
                Assert.AreEqual("Invalid Email", errorMessage);
            }
            else if (_companySignUpPage.IsPasswordErrorDisplayd(out errorMessage))
            {
                Assert.AreEqual("Required", errorMessage);
            }
            else if (_companySignUpPage.IsMainErrorDisplayd(out errorMessage))
            {
                Assert.AreEqual("Please enter a correct email and password.",errorMessage);
            }
            Assert.Pass();
        }
    }
}