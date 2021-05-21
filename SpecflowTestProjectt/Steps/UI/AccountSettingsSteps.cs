using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SeleniumTests.ProfileTests;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class AccountSettingsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly AccountSettingsPage _accountSettingsPage;

        public AccountSettingsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _accountSettingsPage = new AccountSettingsPage(_webDriver);
        }

        [Given(@"Client is authorized")]
        public void GivenClientIsAuthorized()
        {
            var user = CreateUserViaApi();
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = driver;

            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");

            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/profile/edit");
        }

        [Given(@"Account Settings page is opened")]
        public void GivenAccountSettingsPageIsOpened()
        {
            _accountSettingsPage.OpenPage();
        }

        [When(@"I click on edit password button on Account Settings page")]
        public void WhenIClickEditPasswordButtonOnAccountSettingsPage()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _accountSettingsPage.ClickEditPasswordButton();
        }

        [When(@"I input client '(.*)' at Current password field in the Password Edit Block")]
        public void WhenIInputPasswordEditPasswordBlock(string currentPassword)
        {
            _accountSettingsPage.SetCurrentPasswordEditPasswordBlock(currentPassword);
        }

        [When(@"I input new password '(.*)' at New password field in the Password Edit Block")]
        public void WhenIInputNewPasswordEditPasswordBlock(string newPassword)
        {
            _accountSettingsPage.SetNewPasswordEditPasswordBlock(newPassword);
        }

        [When(@"I input new password '(.*)' at New password confirm field in the Password Edit Block")]
        public void WhenIInputNewPasswordConfirmEditPasswordBlock(string newPasswordConfirm)
        {
            _accountSettingsPage.SetNewPasswordConfirmEditPasswordBlock(newPasswordConfirm);
        }

        [When(@"I click Save changes button at at the Edit Password Block")]
        public void WhenIClickEditPasswordBlockSubmitButton()
        {
            _accountSettingsPage.ClickEditPasswordBlockSubmitButton();
        }

        [Then(@"I see error message '(.*)' on the Account Settings page")]
        public void WhenIInputInvalidEmail(string message)
        {
            Assert.AreEqual(message, _accountSettingsPage.SeeNotificationMessageInvalidOldPassword());
        }
    }
}