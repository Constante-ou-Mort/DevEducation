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
        public bool IsExceptionMessageVisible()
        {
            return true;
        }
    }
}