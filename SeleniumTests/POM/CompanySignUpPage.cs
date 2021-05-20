using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class CompanySignUpPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _emailAndPasswordErrorLocator = By.CssSelector("[class^=FormErrorText__error]");
        private readonly By _mainErrorLocator =
            By.XPath("//*[contains(@class, 'FormCard')]//../../../div[contains(@class, 'FormErrorText')]//div");
        
        public CompanySignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsPageTitleVisible()
        {
            return true;
        }
        
        public bool IsEmailErrorDisplayd(out string errorMessage)
        {
            var error = _webDriver.FindElements(_emailAndPasswordErrorLocator);
            errorMessage = error[0].Text;

            if (error[0].Displayed)
            {
                return true;
            }

            return false;
        }
        
        public bool IsPasswordErrorDisplayd(out string errorMessage)
        {
            var error = _webDriver.FindElements(_emailAndPasswordErrorLocator);
            errorMessage = error[1].Text;

            if (error[1].Displayed)
            {
                return true;
            }

            return false;
        }
        
        public bool IsMainErrorDisplayd(out string errorMessage)
        {
            var error = _webDriver.FindElement(_mainErrorLocator);
            errorMessage = error.Text;

            if (error.Displayed)
            {
                return true;
            }

            return false;
        }
    }
}