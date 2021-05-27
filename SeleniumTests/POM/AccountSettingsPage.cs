using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM
{
    public class AccountSettingsPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _passwordEditButton = By.XPath("//div[3]/div[1]/nb-account-info-password[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static readonly By _currentPasswordEditPasswordBlock = By.CssSelector("common-input[formcontrolname = old_password] label > input");
        private static readonly By _newPasswordEditPasswordBlock = By.CssSelector("common-input[formcontrolname = new_password] label > input");
        private static readonly By _newPasswordConfirmationEditPasswordBlock = By.CssSelector("common-input[formcontrolname = newPasswordConfirmation] label > input");
        private static readonly By _passwordEditPasswordBlockSubmitButton = By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component/nb-account-info-edit/common-border/div[3]/div/nb-account-info-password/form/div[2]/div/common-button-deprecated/button");
        private static readonly By _invalidPasswordNotification = By.XPath("span[ class ^= header-notification]");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSettingsPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public AccountSettingsPage ClickEditPasswordButton()
        {
            _webDriver.FindElement(_passwordEditButton).Click();
            return this;
        }

        public AccountSettingsPage SetCurrentPasswordEditPasswordBlock(string currentPassword)
        {
            _webDriver.FindElement(_currentPasswordEditPasswordBlock).SendKeys(currentPassword);
            return this;
        }

        public AccountSettingsPage SetNewPasswordEditPasswordBlock(string newPassword)
        {
            _webDriver.FindElement(_newPasswordEditPasswordBlock).SendKeys(newPassword);
            return this;
        }

        public AccountSettingsPage SetNewPasswordConfirmEditPasswordBlock(string newPasswordConfirm)
        {
            _webDriver.FindElement(_newPasswordConfirmationEditPasswordBlock).SendKeys(newPasswordConfirm);
            return this;
        }

        public void ClickEditPasswordBlockSubmitButton()
        {
            _webDriver.FindElement(_passwordEditPasswordBlockSubmitButton).Click();
            return;
        }

        public string SeeNotificationMessageInvalidOldPassword()
        {
            return _webDriver.FindElement(_invalidPasswordNotification).Text;
        }

        public bool IsSignInPageIsOpen()
        {
            if (_webDriver.Url == "https://newbookmodels.com/account-settings/account-info/edit")
                return true;
            return false;
        }
    }
}
