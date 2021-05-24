using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POM.AccountSettings
{
    public class AccountInfoPage
    {
        private readonly IWebDriver _webDriver;

        
        private static readonly By _generalInformationEditButton = By.CssSelector("nb-account-info-general-information form div div nb-edit-switcher div[class ^= 'edit-switcher']");
        private static readonly By _generalInformationCancelEditButton = By.CssSelector("nb-account-info-general-information form div div nb-edit-switcher div[class ^= 'paragraph']");
        private static readonly By _firstNameFieldEditGeneralInformationBlock = By.CssSelector("nb-account-info-general-information common-input[formcontrolname = 'first_name'] input");
        private static readonly By _lastNameFieldEditGeneralInformationBlock = By.CssSelector("nb-account-info-general-information common-input[formcontrolname = 'last_name'] input");
        private static readonly By _companyLocationFieldEditGeneralInformationBlock = By.CssSelector("common-google-maps-autocomplete input");
        private static readonly By _companyLocationSelectEditGeneralInformationBlock = By.CssSelector("//div[@class = 'pac-item'] [1]");
        private static readonly By _industryFieldEditGeneralInformationBlock = By.CssSelector("nb-account-info-general-information common-input[formcontrolname = 'industry'] input");
        private static readonly By _saveChangesButtonEditGeneralInformationBlock = By.CssSelector("nb-account-info-general-information common-button-deprecated button[type = 'submit']");

        private static readonly By _emailEditButton = By.CssSelector("nb-account-info-email-address form div div nb-edit-switcher div[class ^= 'edit-switcher']");
        private static readonly By _emailCancelEditButton = By.CssSelector("nb-account-info-email-address form div div nb-edit-switcher div[class ^= 'paragraph']");
        private static readonly By _currentPasswordFieldEditEmailBlock = By.CssSelector("nb-account-info-email-address common-input[formcontrolname = 'password'] input");
        private static readonly By _newEmailEditFieldEmailBlock = By.CssSelector("nb-account-info-email-address common-input[formcontrolname = 'email'] input");
        private static readonly By _saveChangesButtonEditEmailBlock = By.CssSelector("nb-account-info-email-address common-button-deprecated button[type = 'submit']");

        private static readonly By _passwordEditButton = By.CssSelector("nb-account-info-password nb-edit-switcher div div");
        private static readonly By _passwordCancelEditButton = By.CssSelector("nb-account-info-password form div div nb-edit-switcher div[class ^= 'paragraph']");
        private static readonly By _currentPasswordFieldEditPasswordBlock = By.CssSelector("nb-account-info-password common-input[formcontrolname = old_password]");
        private static readonly By _newPasswordFieldEditPasswordBlock = By.CssSelector("nb-account-info-password common-input[formcontrolname = new_password] input");
        private static readonly By _newPasswordConfirmationFieldEditPasswordBlock = By.CssSelector("nb-account-info-password common-input[formcontrolname = newPasswordConfirmation] input");
        private static readonly By _saveChangesButtonEditPasswordBlock = By.CssSelector("nb-account-info-password common-button-deprecated button[type = 'submit']");

        private static readonly By _phoneEditButton = By.CssSelector("nb-account-info-phone nb-edit-switcher div div]");
        private static readonly By _phoneCancelEditButton = By.CssSelector("nb-account-info-phone div div nb-edit-switcher div[class ^= 'paragraph']");
        private static readonly By _currentPasswordFieldEditPhoneBlock = By.CssSelector("nb-account-info-phone common-input[formcontrolname ='password'] input");
        private static readonly By _newPhoneFieldEditPhoneBlock = By.CssSelector("nb-account-info-phone common-input-phone[formcontrolname ='phone_number'] input");
        private static readonly By _saveChangesButtonEditPhoneBlock = By.CssSelector("nb-account-info-email-address common-button-deprecated button[type = 'submit']");

        private static readonly By _invalidPasswordNotification = By.CssSelector("span[ class ^= 'header-notification']");

        private static readonly By _logOutButton = By.CssSelector("nb-link[ type = 'logout']");

        public AccountInfoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountInfoPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public AccountInfoPage ClickEditPasswordButton()
        {
            _webDriver.FindElement(_passwordEditButton).Click();
            return this;
        }

        public AccountInfoPage SetCurrentPasswordEditPasswordBlock(string currentPassword)
        {
            _webDriver.FindElement(_currentPasswordFieldEditPasswordBlock).SendKeys(currentPassword);
            return this;
        }

        public AccountInfoPage SetNewPasswordEditPasswordBlock(string newPassword)
        {
            _webDriver.FindElement(_newPasswordFieldEditPasswordBlock).SendKeys(newPassword);
            return this;
        }

        public AccountInfoPage SetNewPasswordConfirmEditPasswordBlock(string newPasswordConfirm)
        {
            _webDriver.FindElement(_newPasswordConfirmationFieldEditPasswordBlock).SendKeys(newPasswordConfirm);
            return this;
        }

        public void ClickEditPasswordBlockSubmitButton()
        {
            _webDriver.FindElement(_saveChangesButtonEditPasswordBlock).Click();
            return;
        }

        public string SeeNotificationMessageInvalidOldPassword()
        {
            return _webDriver.FindElement(_invalidPasswordNotification).Text;
        }
    }
}
