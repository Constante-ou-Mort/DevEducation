using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace SeleniumTests.POM
{
    public class SignUpPage
    {
        public readonly IWebDriver _webDriver;

        private static readonly By _firstName = By.CssSelector("[name= first_name]");
        private static readonly By _lastName = By.CssSelector("[name= last_name]");
        private static readonly By _email = By.CssSelector("[name= email]");
        private static readonly By _password = By.CssSelector("[name= password]");
        private static readonly By _passwordConfirm = By.CssSelector("[name= password_confirm]");
        private static readonly By _phone = By.CssSelector("[name=phone_number]");
        private static readonly By _nextButton = By.CssSelector("[class^=SignupForm__submitButton]");

        public SignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }
        public string GetUrl()
        {
            return _webDriver.Url;
        }
        public SignUpPage SetFirstName(string firstNane)
        {
            _webDriver.FindElement(_firstName).SendKeys(firstNane);
            return this;
        }
        public SignUpPage SetLastName(string lastNane)
        {
            _webDriver.FindElement(_lastName).SendKeys(lastNane);
            return this;
        }
        public SignUpPage SetEmail(string email)
        {
            _webDriver.FindElement(_email).SendKeys(email);
            return this;
        }
        public SignUpPage SetPassword(string password)
        {
            _webDriver.FindElement(_password).SendKeys(password);
            return this;
        }
        public SignUpPage SetConfirmPassword(string passwordConfirm)
        {
            _webDriver.FindElement(_passwordConfirm).SendKeys(passwordConfirm);
            return this;
        }
        public SignUpPage SetPhone(string phone)
        {
            _webDriver.FindElement(_phone).SendKeys(phone);
            return this;
        }
        public void ClickNextButton()
        {
            _webDriver.FindElement(_nextButton).Click();
        }
    }
}
