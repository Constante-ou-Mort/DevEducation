using SpecflowTestProject.RegistrationPage;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RegistrationPage.RegistrationPage _registrationPage;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _registrationPage = new RegistrationPage.RegistrationPage(webDriver);
        }
        
        [Given(@"Sign up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _registrationPage.OpenPage();
        }

        [When(@"I sign up with data")]
        public void ISignUpWithData(Table table)
        {
            var signInModels = table.CreateInstance<SignInModel>();

            _registrationPage.SetFirstName(signInModels.FirstName);
            _registrationPage.SetSecondName(signInModels.LastName);
            _registrationPage.SetEmail();
            _registrationPage.SetPassword(signInModels.Password);
            _registrationPage.SetConfirmPassword(signInModels.ConfirmPassword);
            _registrationPage.SetPhomeNumber(signInModels.Password);

            _registrationPage.ClickSubmit();
        }

        public class SignInModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Mobile { get; set; }

            //public SignInModel()
            //{
            //    Email = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
            //}
        }

        [Then(@"Next page is opened")]
        public void NextPageIsOpened()
        {
            _registrationPage.OpenPage();
        }



    }
}