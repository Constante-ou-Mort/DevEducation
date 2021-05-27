using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject.Pages
{

    public class ChangeInformationPage
    {
        public IWebDriver _webDriver;

        private static readonly By _changeMailButtonLocator = By.XPath("(//div[@class = 'edit-switcher__icon_type_edit'])[2]");
        private static readonly By _emailFieldLocator = By.XPath("//input[@placeholder = 'Enter E-mail']");
        private static readonly By _passwordForChangeEmailLocator = By.XPath("//input[@placeholder = 'Enter Password']");
        private static readonly By _saveChangesForEmailButton = By.XPath(("//button[@class= 'button button_type_default'][0]"));


        public ChangeInformationPage(IWebDriver Driver)
        {
            _webDriver = Driver;
        }

        public ChangeInformationPage GoToChangeInformationPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public ChangeInformationPage ClickChangeEmailButton()
        {
            _webDriver.FindElement(_changeMailButtonLocator).Click();
            return this;
        }

        public ChangeInformationPage SetPassForChangeEmail(string password)
        {
            _webDriver.FindElement(_passwordForChangeEmailLocator).SendKeys(password);
            return this;
        }

        public ChangeInformationPage SetNewEmail(string email)
        {
            _webDriver.FindElement(_emailFieldLocator).SendKeys(email);
            return this;
        }

        public ChangeInformationPage ClickSubmitWithChangedEmail()
        {
            _webDriver.FindElement(_saveChangesForEmailButton).Click();
            return this;
        }

        public string GetSettedEmail()
        {
            var res = _webDriver.FindElement(_emailFieldLocator).Text;
            return res;
        }
    }
}