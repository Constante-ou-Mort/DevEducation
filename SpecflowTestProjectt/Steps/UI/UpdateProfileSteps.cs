using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.PageObject;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject.Features
{
    [Binding]
    public class UpdateProfileSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly UpdateProfilePage _updateProfilePage;

        public UpdateProfileSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            _updateProfilePage = new UpdateProfilePage(webDriver);
        }
        
        [Given(@"Update Profile page is opened")]
        public void GivenUpdateProfilePageIsOpened()
        {
            var user = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Constants.User).Model.TokenData.Token;
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var webDriver = _scenarioContext.Get<IWebDriver>(Constants.WebDriver);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;

            webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{user}');");

            webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        }
        
        [When(@"I update profile with data on UpdateProfile page")]
        public void WhenIUpdateProfileWithDataOnUpdateProfilePage(Table table)
        {
            _updateProfilePage.ClickChangeGeneralInfo();
            _updateProfilePage.SetNewName(table.Rows[0]["name"]);
            _updateProfilePage.SetNewLastName(table.Rows[0]["last_name"]);
            _updateProfilePage.SetIndustry(table.Rows[0]["industry"]);
            _updateProfilePage.SetLocation(table.Rows[0]["company_location"]);
            _updateProfilePage.ClickSaveGeneralChanges();
        }
        
        [Then(@"Successfully changed name to (.*), industry to (.*), company location to (.*) on update profile page")]
        public void ThenSuccessfullyChangedGeneralInformationOnUpdateProfilePage(string name, string industry, string location)
        {
            Assert.AreEqual(name, _updateProfilePage.GetNewName());
            Assert.AreEqual(industry, _updateProfilePage.GetNewIndustry());
            Assert.AreEqual(location, _updateProfilePage.GetNewLocation());
        }
    }
}
