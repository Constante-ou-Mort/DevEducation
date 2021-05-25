using OpenQA.Selenium;

namespace SeleniumTests.POM.SignUp
{
    public class ClientSignUpPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _firstNameField = By.CssSelector("input[name = 'first_name']");
        private static readonly By _lastNameField = By.CssSelector("input[name = 'last_name']");
        private static readonly By _emailField = By.CssSelector("input[name = 'email']");
        private static readonly By _passwordField = By.CssSelector("input[name = 'password']");
        private static readonly By _confirmPasswordField = By.CssSelector("input[name = 'password_confirm']");
        private static readonly By _phoneField = By.CssSelector("input[name = 'phone_number']");
        private static readonly By _refferalCodeField = By.CssSelector("input[name = 'code']");
        private static readonly By _nextButton = By.CssSelector("button[type = 'submit']");

        public ClientSignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ClientSignUpPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

        public ClientSignUpPage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }

        public ClientSignUpPage SetLastName(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public ClientSignUpPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public ClientSignUpPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public ClientSignUpPage SetConfirmPassword(string password)
        {
            _webDriver.FindElement(_confirmPasswordField).SendKeys(password);
            return this;
        }

        public ClientSignUpPage SetPhone(string phone)
        {
            _webDriver.FindElement(_phoneField).SendKeys(phone);
            return this;
        }

        public ClientSignUpPage SetRefferalCode(string code)
        {
            _webDriver.FindElement(_refferalCodeField).SendKeys(code);
            return this;
        }

        public void ClickNextButton()
        {
            _webDriver.FindElement(_nextButton).Click();
        }

        public string SeeErrorMessageNearField(string message)
        {
            var messageText = _webDriver.FindElement(By.XPath($"//*[contains(text(), '{message}')]")).Text;
            return messageText;
        }
    }
}
