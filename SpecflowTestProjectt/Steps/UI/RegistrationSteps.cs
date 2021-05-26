using SpecflowTestProject.Pages;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System;
using NUnit.Framework;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RegistrationPage _registrationPage;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _registrationPage = new RegistrationPage(webDriver);
        }
        
        [Given(@"Sign up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _registrationPage.OpenPage();
        }

        [When(@"I write this information on the first page")]
        public void ISignUpWithDataOnFirstPage(Table table)
        {
            var signInModels = table.CreateInstance<SignInModelForFirstPage>();

            _registrationPage.SetFirstName(signInModels.FirstName);
            _registrationPage.SetSecondName(signInModels.LastName);
            _registrationPage.SetEmail();
            _registrationPage.SetPassword(signInModels.Password);
            _registrationPage.SetConfirmPassword(signInModels.ConfirmPassword);
            _registrationPage.SetPhomeNumber(signInModels.Mobile);

            _registrationPage.ClickSubmit();
        }

        public class SignInModelForFirstPage
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Mobile { get; set; }
        }

        [When(@"I write this information on the second page")]
        public void ISignUpWithDataOnSecondPage(Table table)
        {
            var signInModels = table.CreateInstance<SignInModelForSecondPage>();

            _registrationPage.SetCompanyName(signInModels.CompanyName);
            _registrationPage.SetCompanySite(signInModels.CompanyUrl);
            _registrationPage.SetLocationField(signInModels.Address);
            _registrationPage.SetIndustryLocator();            

            _registrationPage.ClickSubmit();
        }

        public class SignInModelForSecondPage
        {
            public string CompanyName { get; set; }
            public string CompanyUrl { get; set; }
            public string Address { get; set; }            
        }

        [Then(@"Next page is opened")]
        public void NextPageIsOpened()
        {
            System.Threading.Thread.Sleep(1000);
            var url = _registrationPage.GetUrl();
            _registrationPage.OpenPage();
            Assert.AreEqual("https://newbookmodels.com/explore", url);
        }
    }
}