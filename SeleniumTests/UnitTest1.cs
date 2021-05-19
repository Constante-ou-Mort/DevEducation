using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumTests
{
    public class Tests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void Test1()
        {
            _webDriver.Navigate().GoToUrl("https://rozetka.com.ua/");
            var searchField = _webDriver.FindElement(By.CssSelector(
                "body > app-root > div > div:nth-child(3) > rz-header > header > div > div > div > form > div > div > input"));
            searchField.SendKeys("Пасхальный набор");
            _webDriver.FindElement(By.CssSelector(
                    "body > app-root > div > div:nth-child(3) > rz-header > header > div > div > div > form > button"))
                .Click();
            var actualFirstPosition = _webDriver.FindElement(By.CssSelector(
                "body > app-root > div > div:nth-child(3) > rz-search > rz-catalog > div > div.layout.layout_with_sidebar > section > rz-grid > ul > li:nth-child(1) > app-goods-tile-default > div > div.goods-tile__inner > a.goods-tile__heading.ng-star-inserted > span"));
            
            Assert.AreEqual("Набор Spell Семейная пасхальная корзина 8 позиций (7500000311111)",
                actualFirstPosition.Text.Trim());
        }

        [Test]
        public void Test2()
        {
            _webDriver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/draganddrop/#Photo%20Manager");
            _webDriver.Manage().Window.Maximize();
            var builder = new Actions(_webDriver);
            
            _webDriver.SwitchTo().Frame(_webDriver.FindElement(By.CssSelector("div[rel-title='Photo Manager'] iframe")));
            var picture = _webDriver.FindElement(By.CssSelector("#gallery > li:nth-child(1)"));
            var trash = _webDriver.FindElement(By.CssSelector("trash"));
            builder.DragAndDrop(picture,trash).Build().Perform();
        }
    }
}