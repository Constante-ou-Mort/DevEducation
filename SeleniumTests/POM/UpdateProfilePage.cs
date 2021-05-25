using OpenQA.Selenium;
using System.Threading;

namespace SeleniumTests.PageObject
{
    public class UpdateProfilePage
    {
        private IWebDriver _webDriver;

        private static By _logOutButton = By.CssSelector("[class='link link_type_logout link_active']");
        private static By _changeGeneralDataButton = By.CssSelector(" nb-account-info-general-information > form > div:nth-child(1) > div > nb-edit-switcher > div");
        private static By _changeEmailButton = By.CssSelector("nb-account-info-email-address>form>div:nth-child(1)>div>nb-edit-switcher>div>div");
        private static By _changePasswordButton = By.CssSelector("nb-account-info-password div:nth-child(1)>div>nb-edit-switcher>div>div");
        private static By _changePhoneButton = By.CssSelector("nb-account-info-phone>div:nth-child(1)>div>nb-edit-switcher>div>div");
        private static By _companyLocationfield = By.CssSelector("[class='input__self input__self_type_text-underline ng-untouched ng-pristine ng-valid pac-target-input']");
        private static By _industryField = By.CssSelector("input[placeholder='Enter Industry']");
        private static By _nameField = By.CssSelector("common-input:nth-child(3) input");
        private static By _lastNameField = By.CssSelector("common-input:nth-child(4) input");
        private static By _saveGeneralButton = By.CssSelector("div:nth-child(2) > div > common-button-deprecated > button");
        private static By _newName = By.CssSelector("nb-paragraph:nth-child(3)>div");
        private static By _newLocation = By.CssSelector("nb-paragraph:nth-child(5)>div");
        private static By _newIndustry = By.CssSelector("nb-paragraph:nth-child(7)>div");
        private static By _emailPassword = By.CssSelector("[type = password]");
        private static By _changeEmail = By.CssSelector("[type = text]");
        private static By _saveEmailButton = By.CssSelector("[type = submit]");
        private static By _newEmail = By.CssSelector("div>div:nth-child(1)>span");
        private static By _currentPassword = By.CssSelector("common-input:nth-child(2)  input");
        private static By _changePasswordFirstField = By.CssSelector("nb-account-info-password common-input:nth-child(4) input");
        private static By _changePasswordSecondField = By.CssSelector("nb-account-info-password common-input:nth-child(6) input");
        private static By _savePasswordButton = By.CssSelector("[type = submit]");
        private static By _phonePassword = By.CssSelector("[type = password]");
        private static By _changePhone = By.CssSelector("common-input-phone>label>input");
        private static By _savePhoneButton = By.CssSelector("common-button-deprecated:nth-child(5)>button");
        private static By _newPhone = By.CssSelector("nb-paragraph.mt-2>div>span");
        private static By _addCardName = By.CssSelector("input[placeholder ='Full name']");
        private static By _addCardNumber = By.CssSelector("#root > form > div > div.CardField-input-wrapper.is-ready-to-slide > span.CardField-number.CardField-child > span:nth-child(2) > div > div.CardNumberField-input-wrapper > span > input");
        private static By _addCardDate = By.CssSelector("[name = exp-date]");
        private static By _addCardCVC = By.CssSelector("[name = cvc]");
        private static By _saveCard = By.CssSelector("[type = submit]");
        private static By _exceptionCardInfoError = By.CssSelector("[class^='header-notification__text']");
        private static By _profileChanges = By.CssSelector("[class='link link_type_navigation']");
        private static By _userIcon = By.CssSelector("div.avatar__image");

        public UpdateProfilePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public UpdateProfilePage GoToUpdateProfileLink()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public UpdateProfilePage ClickChangeGeneralInfo()
        {
            _webDriver.FindElement(_changeGeneralDataButton).Click();
            return this;
        }

        public UpdateProfilePage ClickProfileChanges()
        {
            _webDriver.FindElement(_profileChanges).Click();
            return this;
        }

        public UpdateProfilePage SetFullNameToCardField(string name)
        {
            _webDriver.FindElement(_addCardName).SendKeys(name);
            return this;
        }

        public UpdateProfilePage SetCardNumber(string cardNumber)
        {
            _webDriver.FindElement(_addCardNumber).SendKeys(cardNumber);
            return this;
        }

        public UpdateProfilePage SetCardExpDate(string date)
        {
            _webDriver.FindElement(_addCardDate).SendKeys(date);
            return this;
        }

        public UpdateProfilePage SetCardCVC(string cardCVC)
        {
            _webDriver.FindElement(_addCardCVC).SendKeys(cardCVC);
            return this;
        }

        public UpdateProfilePage ClickSaveCard()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(_saveCard).Click();
            Thread.Sleep(1000);
            return this;
        }

        public UpdateProfilePage ClickPhoneChange()
        {
            _webDriver.FindElement(_changePhoneButton).Click();
            return this;
        }

        public UpdateProfilePage SetPhonePassword(string currentPassword)
        {
            _webDriver.FindElement(_phonePassword).SendKeys(currentPassword);
            return this;
        }

        public UpdateProfilePage SetNewPhone(string newPhone)
        {
            _webDriver.FindElement(_changePhone).SendKeys(newPhone);
            return this;
        }

        public UpdateProfilePage ClickSavePhone()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(_savePhoneButton).Click();
            Thread.Sleep(1000);
            return this;
        }

        public UpdateProfilePage ClickPasswordChange()
        {
            _webDriver.FindElement(_changePasswordButton).Click();
            return this;
        }

        public UpdateProfilePage SetCurrentPassword(string currentPassword)
        {
            _webDriver.FindElement(_currentPassword).SendKeys(currentPassword);
            return this;
        }

        public UpdateProfilePage SetNewPasswordFirst(string newPassword)
        {
            _webDriver.FindElement(_changePasswordFirstField).SendKeys(newPassword);
            return this;
        }

        public UpdateProfilePage SetNewPasswordSecond(string newPassword)
        {
            _webDriver.FindElement(_changePasswordSecondField).SendKeys(newPassword);
            return this;
        }

        public UpdateProfilePage ClickSavePasswords()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(_savePasswordButton).Click();
            Thread.Sleep(1000);
            return this;
        }

        public UpdateProfilePage SetNewName(string name)
        {
            var nameField = _webDriver.FindElement(_nameField);
            nameField.Clear();
            nameField.SendKeys(name);
            return this;
        }

        public UpdateProfilePage SetNewLastName(string lastName)
        {
            var lastNameField = _webDriver.FindElement(_lastNameField);
            lastNameField.Clear();
            lastNameField.SendKeys(lastName);
            return this;
        }

        public UpdateProfilePage SetLocation(string location)
        {
            var locationField = _webDriver.FindElement(_companyLocationfield);
            locationField.SendKeys(location);
            Thread.Sleep(500);
            locationField.SendKeys(Keys.Down);
            locationField.SendKeys(Keys.Enter);
            return this;
        }

        public UpdateProfilePage SetIndustry(string industry)
        {
            _webDriver.FindElement(_industryField).SendKeys(industry);
            return this;
        }

        public UpdateProfilePage ClickSaveGeneralChanges()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(_saveGeneralButton).Click();
            Thread.Sleep(1000);
            return this;
        }

        public UpdateProfilePage ClickLogOutButton()
        {
            _webDriver.FindElement(_logOutButton).Click();
            return this;
        }

        public UpdateProfilePage ClickEmailChange()
        {
            _webDriver.FindElement(_changeEmailButton).Click();
            return this;
        }

        public UpdateProfilePage SetPasswordEmail(string password)
        {
            _webDriver.FindElement(_emailPassword).SendKeys(password);
            return this;
        }

        public UpdateProfilePage SetNewEmail(string email)
        {
            _webDriver.FindElement(_changeEmail).SendKeys(email);
            return this;
        }

        public UpdateProfilePage ClickSaveEmail()
        {
            Thread.Sleep(500);
            _webDriver.FindElement(_saveEmailButton).Click();
            Thread.Sleep(1000);
            return this;
        }

        public string GetNewEmail() => _webDriver.FindElement(_newEmail).Text;

        public string GetNewName() => _webDriver.FindElement(_newName).Text;

        public string GetNewIndustry() => _webDriver.FindElement(_newIndustry).Text;

        public string GetNewLocation() => _webDriver.FindElement(_newLocation).Text;

        public string GetNewPhone() => _webDriver.FindElement(_newPhone).Text;

        public string GetUserPhoto() => _webDriver.FindElement(_userIcon).Text;

        public string GetExceprionCardInfoError() => _webDriver.FindElement(_exceptionCardInfoError).Text;
    }
}