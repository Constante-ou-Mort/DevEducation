using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
        }

        [Given(@"Sign up page is opened")]
        public void GivenSignUpPageIsOpened()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
        }
        
        [When(@"I register with data")]
        public void WhenIRegisterWithData(Table table)
        {
            var registrationModels = table.CreateSet<RegistrationModel>().ToList();

            _webDriver.FindElement(By.CssSelector("[name^=first_name]")).SendKeys(registrationModels[0].FirstName);
            _webDriver.FindElement(By.CssSelector("[name^=last_name]")).SendKeys(registrationModels[0].LastName);
            _webDriver.FindElement(By.CssSelector("[name^=email]")).SendKeys(registrationModels[0].Email);
            _webDriver.FindElement(By.CssSelector("[name=phone_number]")).SendKeys(registrationModels[0].Mobile);
            _webDriver.FindElement(By.CssSelector("[name=password]")).SendKeys(registrationModels[0].Password);
            _webDriver.FindElement(By.CssSelector("[name=password_confirm]")).SendKeys(registrationModels[0].Password);            
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();
        }
        
        [Then(@"Succesfully registration in NewBookModels")]
        public void ThenSuccesfullyRegistrationInNewBookModels()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.UrlToBe("https://newbookmodels.com/join/company"));
            Assert.AreEqual(_webDriver.Url, "https://newbookmodels.com/join/company");
        }

        public class RegistrationModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Mobile { get; set; }
        }
    }
}
