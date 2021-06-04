using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook
{
    public class SignUpPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _nameField = By.CssSelector("[name = first_name]");
        private static readonly By _lastNameField = By.CssSelector("[name = last_name]");
        private static readonly By _emailField = By.CssSelector("[name = email]");
        private static readonly By _passwordField = By.CssSelector("[name = password]");
        private static readonly By _passwordConfirmField = By.CssSelector("[name = password_confirm]");
        private static readonly By _numberField = By.CssSelector("[name= phone_number]");
        private static readonly By _registrationButton = By.CssSelector("[type = submit]");

        public SignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpPage OpenSignUpPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

        public SignUpPage SetName(string name)
        {
            _webDriver.FindElement(_nameField).SendKeys(name);
            return this;
        }

        public SignUpPage SetLastName(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public SignUpPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignUpPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public SignUpPage SetPasswordConfirm(string passwordConfirm)
        {
            _webDriver.FindElement(_passwordConfirmField).SendKeys(passwordConfirm);
            return this;
        }

        public SignUpPage SetPhoneNumber(string number)
        {
            _webDriver.FindElement(_numberField).SendKeys(number);
            return this;
        }

        public void ClickRegistrationButton()
        {
            _webDriver.FindElement(_registrationButton).Click();
        }
    }
}

