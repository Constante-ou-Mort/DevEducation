using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.PageObject;
using System;
using TechTalk.SpecFlow;

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
            _updateProfilePage.GoToUpdateProfileLink();
        }
        
        [When(@"I update profile with data on UpdateProfile page")]
        public void WhenIUpdateProfileWithDataOnUpdateProfilePage(Table table)
        {
            _updateProfilePage.ClickChangeGeneralInfo();
            _updateProfilePage.SetNewName(table.Rows[0]["name"]);
            _updateProfilePage.SetNewName(table.Rows[0]["last_name"]);
            _updateProfilePage.SetNewName(table.Rows[0]["industry"]);
            _updateProfilePage.SetNewName(table.Rows[0]["company_location"]);
        }
        
        [Then(@"Successfully changed General Information on update profile page")]
        public void ThenSuccessfullyChangedGeneralInformationOnUpdateProfilePage()
        {
            _updateProfilePage.GetNewLocation();

            Assert.AreEqual("Lili Bom", _updateProfilePage.GetNewName());
            Assert.AreEqual("fashion", _updateProfilePage.GetNewIndustry());
            Assert.AreEqual("Gatlinburg, TN 37738, USA", _updateProfilePage.GetNewLocation());
        }
    }
}
