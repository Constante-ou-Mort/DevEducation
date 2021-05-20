using SpecflowTestProject.RegistrationPage;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RegistrationPage.RegistrationPage RegistrationPage;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            RegistrationPage = new RegistrationPage.RegistrationPage(webDriver);
        }
        
        [Given(@"Sign up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            RegistrationPage.OpenPage();
        }
        
    }
}