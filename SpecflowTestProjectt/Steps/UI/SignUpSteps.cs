using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SeleniumTests.POM.SignUp;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly ClientSignUpPage _clientSignUpPage;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _clientSignUpPage = new ClientSignUpPage(_webDriver);
        }

        [Given(@"Sign Up page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _clientSignUpPage.OpenPage();
        }

        [When(@"I input '(.*)' in first name field on Sign Up page")]
        public void WhenIInputFirstNameOnSignUpPage(string firstName)
        {
            _clientSignUpPage.SetFirstName(firstName);
        }

        [When(@"I input '(.*)' in last name field on Sign Up page")]
        public void WhenIInputLastNameOnSignUpPage(string lastName)
        {
            _clientSignUpPage.SetLastName(lastName);
        }

        [When(@"I input (.*) in email field on Sign Up page")]
        public void WhenIInputOnSignUpPage(string email)
        {
            _clientSignUpPage.SetEmail(email);
        }

        [When(@"I input (.*) in password field on Sign Up page")]
        public void WhenIInputPasswordOnSignUpPage(string password)
        {
            _clientSignUpPage.SetPassword(password);
        }

        [When(@"I input (.*) in password confirm field on Sign Up page")]
        public void WhenIInputPasswordConfirmOnSignUpPage(string password)
        {
            _clientSignUpPage.SetConfirmPassword(password);
        }

        [When(@"I input '(.*)' in phone field on Sign Up page")]
        public void WhenIInputPhoneOnSignUpPage(string phone)
        {
            _clientSignUpPage.SetPhone(phone);
        }

        [When(@"I click Next button on Sign Up page")]
        public void WhenIClickNextButtonOnSignUpPage()
        {
            _clientSignUpPage.ClickNextButton();
        }
    }
}
