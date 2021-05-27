using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.PageObject;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Features.UI
{
    [Binding]
    public class ChangePhoneNumberSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UpdateProfilePage _updateProfilePage;

        public ChangePhoneNumberSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _updateProfilePage = new UpdateProfilePage(webDriver);
        }

        [When(@"I change phone with data on Update Profile page")]
        public void WhenIChangePhoneWithDataOnUpdateProfilePage(Table table)
        {
            _updateProfilePage.ClickPhoneChange()
                .SetCurrentPassword(Constants.Password)
                .SetNewPhone(table.Rows[0]["new_phone"])
                .ClickSavePhone();
        }
        
        [Then(@"Successfully changed phone to (.*) on update profile page")]
        public void ThenSuccessfullyChangedPhoneToOnUpdateProfilePage(string phone)
        {
            Assert.AreEqual(phone, _updateProfilePage.GetNewPhone());
        }
    }
}
