using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.POM;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumTests
{
    public class SignInPageTests
    {
        private IWebDriver _webDriver;
        private SignInPage _signInPage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            
            _signInPage = new SignInPage(_webDriver);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CheckUserAccountBlockMessage()
        {
            _signInPage.OpenPage()
                .SetEmail("qweqwewe@werwert.erty")
                .SetPassword("123qweQWE!")
                .ClickLoginButton();
            var actualMessage = _signInPage.GetUserAccountBlockMessage();
            
            Assert.AreEqual("User account is blocked.",actualMessage);
        }
    }
}