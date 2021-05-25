using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

        private static readonly By _passwordEditButton = By.CssSelector("nb-account-info-password div[class ^= 'edit-switcher']");
        private static readonly By _passwordCancelEditButton = By.CssSelector("nb-account-info-password form div div nb-edit-switcher div[class ^= 'paragraph']");
        private static readonly By _currentPasswordFieldEditPasswordBlock = By.CssSelector("nb-account-info-password common-input[formcontrolname = old_password] input");
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

        public AccountInfoPage ClickGeneralInformationEditButton()
        {
            _webDriver.FindElement(_generalInformationEditButton).Click();
            return this;
        }

        public AccountInfoPage ClickGeneralInformationCancelEditButton()
        {
            _webDriver.FindElement(_generalInformationCancelEditButton).Click();
            return this;
        }

        public AccountInfoPage SetFirstNameGeneralInformationEditBlock(string firstName)
        {
            _webDriver.FindElement(_firstNameFieldEditGeneralInformationBlock).SendKeys(firstName);
            return this;
        }

        public AccountInfoPage SetLastNameGeneralInformationEditBlock(string lastName)
        {
            _webDriver.FindElement(_lastNameFieldEditGeneralInformationBlock).SendKeys(lastName);
            return this;
        }

        public AccountInfoPage SetCompanyLocationGeneralInformationEditBlock(string location)
        {
            _webDriver.FindElement(_companyLocationFieldEditGeneralInformationBlock).SendKeys(location);
            _webDriver.FindElement(_companyLocationSelectEditGeneralInformationBlock).Click();
            return this;
        }

        public AccountInfoPage SetIndustryInformationEditBlock(string industry)
        {
            _webDriver.FindElement(_industryFieldEditGeneralInformationBlock).SendKeys(industry);
            return this;
        }

        public void ClickSaveChangesButtonGeneralInformationEditBlock()
        {
            _webDriver.FindElement(_saveChangesButtonEditGeneralInformationBlock).Click();
            return;
        }

        public AccountInfoPage ClickEmailEditButton()
        {
            _webDriver.FindElement(_emailEditButton).Click();
            return this;
        }

        public AccountInfoPage ClickEmailCancelEditButton()
        {
            _webDriver.FindElement(_emailCancelEditButton).Click();
            return this;
        }

        public AccountInfoPage SetCurrentPasswordEmailEditBlock(string password)
        {
            _webDriver.FindElement(_currentPasswordFieldEditEmailBlock).SendKeys(password);
            return this;
        }

        public AccountInfoPage SetNewEmailEmailEditBlock(string lastName)
        {
            _webDriver.FindElement(_newEmailEditFieldEmailBlock).SendKeys(lastName);
            return this;
        }

        public void ClickSaveChangesButtonEmailEditBlock()
        {
            _webDriver.FindElement(_saveChangesButtonEditEmailBlock).Click();
            return;
        }

        public AccountInfoPage ClickPasswordEditButton()
        {
            var actions = new Actions(_webDriver);
            IWebElement element = _webDriver.FindElement(_passwordEditButton); 
            actions.MoveToElement(element, 1, 1).Click().Build().Perform();
            return this;
        }

        public AccountInfoPage ClickPasswordCancelEditButton()
        {
            _webDriver.FindElement(_passwordCancelEditButton).Click();
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

        public void ClickSaveChangesButtonEditPasswordBlock()
        {
            _webDriver.FindElement(_saveChangesButtonEditPasswordBlock).Click();
            return;
        }

        public AccountInfoPage ClickPhoneEditButton()
        {
            _webDriver.FindElement(_phoneEditButton).Click();
            return this;
        }

        public AccountInfoPage ClickPhoneCancelEditButton()
        {
            _webDriver.FindElement(_phoneCancelEditButton).Click();
            return this;
        }

        public AccountInfoPage SetCurrentPasswordEditPhoneBlock(string password)
        {
            _webDriver.FindElement(_currentPasswordFieldEditPhoneBlock).SendKeys(password);
            return this;
        }

        public AccountInfoPage SetNewPhoneEditPhoneBlock(string phone)
        {
            _webDriver.FindElement(_newPhoneFieldEditPhoneBlock).SendKeys(phone);
            return this;
        }

        public void ClickSaveChangesButtonEditPhoneBlock()
        {
            _webDriver.FindElement(_saveChangesButtonEditPhoneBlock).Click();
            return;
        }

        public string SeeNotificationMessageInvalidOldPassword()
        {
            return _webDriver.FindElement(_invalidPasswordNotification).Text;
        }

        public void ClickLogOutButton()
        {
            _webDriver.FindElement(_logOutButton).Click();
            return;
        }
    }
}
