using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class CompanySignUpPage
    {
        private readonly IWebDriver _webDriver;

        public CompanySignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsPageTitleVisible()
        {
            return true;
        }
        
        public bool IsErrorDisplayd()
        {
            var element = _webDriver.FindElements(By.XPath("[class^=FormErrorText__error]"));
            var result = element[2].Displayed;
            return result;
        }
    }
}