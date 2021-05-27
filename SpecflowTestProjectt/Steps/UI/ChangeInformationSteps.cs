using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class ChangeInformationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly ChangeInformationPage _changeInformationPage;
        

        public ChangeInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _changeInformationPage = new ChangeInformationPage(_webDriver);
        }

        [Given(@"The profile page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _changeInformationPage.GoToChangeInformationPage();
        }

        [When(@"I click on icon to change my email")]
        public void IClickOnIconToChangeEmail()
        {
            _changeInformationPage.ClickChangeEmailButton();
        }

        [When(@"I write my password to the first field")]
        public void IWriteMyPasswordToTheFirstField()
        {
            _changeInformationPage.SetPassForChangeEmail(Constants.Password);
        }

        [When(@"I write new email to the second field")]
        public void IWriteNewEmailToTheSecondField()
        {
            _changeInformationPage.SetNewEmail("nice@nice.com");
        }

        [When(@"I click Submit button")]
        public void IClickSubmitButton()
        {
            _changeInformationPage.ClickSubmitWithChangedEmail();
        }

        [Then(@"My email is changed")]
        public void CheckChangedEmail()
        {
            var expectedMail = "nice@nice.com";
            var actualMail = _changeInformationPage.GetSettedEmail();

            Assert.AreEqual(expectedMail, actualMail);
        }
    }
}
