using OpenQA.Selenium;

namespace SeleniumTests.POM.SignUp
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
    }
}