using OpenQA.Selenium;
using SeleniumTests.POM;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewBook
{
    public class AccountSettingsPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _generalInfoButton = By.CssSelector("nb-account-info-general-information .edit-switcher__icon_type_edit");
        private static readonly By _emailAddressButton = By.CssSelector("nb-account-info-email-address .edit-switcher__icon_type_edit");
        private static readonly By _passwordButton = By.CssSelector("nb-account-info-password .edit-switcher__icon_type_edit");
        private static readonly By _phoneNumber = By.CssSelector("nb-account-info-phone. edit-switcher__icon_type_edit");
        private static readonly By _logOut = By.CssSelector("[type=logout]");
        private static readonly By _windowVerification = By.CssSelector("common-resend-email div[class = modal__close]");
        private static readonly By _name = By.CssSelector("input[class*=nput__self_type_text-underline]");
        private static readonly By _avatarClient = By.CssSelector(" a.MainHeader__staticItemAvatar--3LwWp");
        private static readonly By _lastName = By.CssSelector("input[class*=nput__self_type_text-underline]");
        private static readonly By _saveButton = By.CssSelector("button[class*=button_type_default]");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSettingsPage OpenSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public AccountSettingsPage ChangeName(string name)
        {
            _webDriver.FindElements(_name)[0].Clear();
            _webDriver.FindElements(_name)[0].SendKeys(name);
            return this;
        }

        public AccountSettingsPage ChangeLastName(string lastName)
        {
            _webDriver.FindElements(_lastName)[1].Clear();
            _webDriver.FindElements(_lastName)[1].SendKeys(lastName);
            return this;
        }

        public void ClickAvatarClient()
        {
            _webDriver.FindElement(_avatarClient).Click();
        }

        public void ClickCloseWindowVerification()
        {
            _webDriver.FindElement(_windowVerification).Click();
        }
        public void ClickGeneralInfoButton()
        {
            _webDriver.FindElement(_generalInfoButton).Click();
        }

        public void ChangeEmailAddress()
        {
            _webDriver.FindElement(_emailAddressButton).Click();
        }

        public void ChangePassword()
        {
            _webDriver.FindElement(_passwordButton).Click();
        }

        public void ChangePhoneNumber()
        {
            _webDriver.FindElement(_phoneNumber).Click();
        }

        public void ClickLogOut()
        {
            _webDriver.FindElement(_logOut).Click();
        }

        public void ClickSaveButton()
        {
            _webDriver.FindElement(_saveButton).Click();
        }

        public void LogIn()
        {
            SingInPage logIn = new SingInPage(_webDriver);
            logIn.OpenPage()
                .SetEmail("juliasjdlnc@gmail.com")
                .SetPassword("julia28091999A!")
                .ClickLoginButton();
        }
    }
}
