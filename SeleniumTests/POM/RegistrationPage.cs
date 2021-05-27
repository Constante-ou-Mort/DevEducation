using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class RegistrationPage
    {
        private readonly IWebDriver _webDriver;

        private By _firstNameField = By.CssSelector("[name = first_name]");
        private By _lastNameField = By.CssSelector("[name = last_name]");
        private By _emailField = By.CssSelector("[name = email]");
        private By _mobileField = By.CssSelector("[name = phone_number]");
        private By _passwordField = By.CssSelector("[name = password]");
        private By _passwordConfirmField = By.CssSelector("[name = password_confirm]");
        private By _nextButton = By.CssSelector(".SignupForm__submitButton--1m1C2");

        public RegistrationPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RegistrationPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }
        public string GetUrl()
        {
            return _webDriver.Url;
        }
        public RegistrationPage SetFirstName(string first_name)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(first_name);
            return this;
        }

        public RegistrationPage SetLastName(string last_name)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(last_name);
            return this;
        }
        public RegistrationPage SetMobile(string number)
        {
            _webDriver.FindElement(_mobileField).SendKeys(number);
            return this;
        }
        public RegistrationPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public RegistrationPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }
        public RegistrationPage SetConfirmPassword(string password)
        {
            _webDriver.FindElement(_passwordConfirmField).SendKeys(password);
            return this;
        }
        public void ClickLoginButton()
        {
            _webDriver.FindElement(_nextButton).Click();
        }
    }
}

