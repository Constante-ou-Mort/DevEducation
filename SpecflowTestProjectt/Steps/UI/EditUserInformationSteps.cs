using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    class EditUserInformationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;

        public EditUserInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);            
        }

        [Given(@"Account settings page is opened")]
        public void GivenAccountSettingsPageIsOpened()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }

        [When(@"I open edit email adress block")]
        public void WhenIOpenEditGeneralIformationBlock()
        {
            _webDriver.FindElement(By.CssSelector("nb-account-info-email-address .edit-switcher__icon_type_edit")).Click();
        }

        [When(@"I input '(.*)' in Current Password field")]
        public void WhenIInputInNewFirstNameField(string password)
        {
            var inputPasswordField = _webDriver.FindElement(By.CssSelector("input[placeholder^=\"Enter Password\"]"));
            inputPasswordField.Clear();
            inputPasswordField.SendKeys(password);
        }

        [When(@"I input '(.*)' in New E-mail Address field")]
        public void WhenIInputInNewLastNameField(string newEmail)
        {
            var inputEmailField = _webDriver.FindElement(By.CssSelector("input[placeholder^=\"Enter E-mail\"]"));
            inputEmailField.Clear();
            inputEmailField.SendKeys(newEmail);
        }

        [When(@"I save schanges in edit email adress block")]
        public void WhenISaveSchanges()
        {
            _webDriver.FindElement(By.CssSelector("nb-account-info-email-address .button")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"Primary Account Holder Name is changed to '(.*)'")]
        public void ThenPrimaryAccountHolderNameIsChangedTo(string newPrimaryAccountHolderName)
        {
            var grayElement = _webDriver.FindElement(By.CssSelector(".paragraph_type_gray div div span"));
            var actualString = grayElement.Text.Trim();

            Assert.AreEqual(_scenarioContext.Get<ClientAuthModel>(Context.User).User.Email, actualString);
        }

    }
}
