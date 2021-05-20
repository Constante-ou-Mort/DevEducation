using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class CompanySignUpPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string _shitSelector = "//*[contains(@class, 'FormCard')]//../../../div[contains(@class, 'FormErrorText')]";
        public CompanySignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsPageTitleVisible()
        {
            return true;
        }

        public bool IsInvalidLoginDisplayd()
        {
            var elem = _webDriver.FindElement(By.XPath(_shitSelector));
            return (elem.Displayed);
        }
    }
}