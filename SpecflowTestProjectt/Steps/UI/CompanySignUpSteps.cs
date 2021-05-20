using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly CompanySignUpPage _companySignUpPage;
        private readonly SingInPage _signInPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
            _signInPage = new SingInPage(_webDriver);
        }

        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }

        //[Then(@"An error message (.*) is displayed in Login Page")]
        //public void ThenUnsuccessfullyLoggedInNewBookModelAsCreatedClient(string message)
        //{
        //    Assert.AreEqual(message, _signInPage.MessageAboutInvalidData());        
        //}
    }
}