using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class SingInPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _emailField = By.CssSelector("input[type=email]");
        private static readonly By _passwordField = By.CssSelector("input[type=password]");
        private static readonly By _loginButton = By.CssSelector("[class^=SignInForm__submitButton]");
        private static readonly By _accountBlockMessage = By.XPath("//*[contains(@class, 'SignInForm__submitButton')]/../../div[contains(@class,'PageForm')][last()]");

        public SingInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SingInPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SingInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SingInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public void ClickLoginButton() =>
            _webDriver.FindElement(_loginButton).Click();

        public string GetUserAccountBlockMessage() => 
            _webDriver.FindElement(_accountBlockMessage).Text;
    }
}