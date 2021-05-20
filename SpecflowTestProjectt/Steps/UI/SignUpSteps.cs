using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SeleniumTests.POM;

namespace SpecflowTestProject.Features
{
    [Binding]
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignUpPage _singUpPage;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _singUpPage = new SignUpPage(webDriver);
        }

        [Given(@"Sign  up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _singUpPage.GoToRegistrationPage();
        }
        
        [When(@"I registrate with data")]
        public void WhenIRegistrateWithData(Table table)
        {
            _singUpPage.SetFirstName(table.Rows[0]["name"]);
            _singUpPage.SetLastName(table.Rows[0]["last_name"]);
            _singUpPage.SetEmail(table.Rows[0]["email"]);
            _singUpPage.SetPassword(table.Rows[0]["password"]);
            _singUpPage.SetPhoneNumber(table.Rows[0]["phone_number"]);

            _singUpPage.ClickNextButton();
        }
    }
}
