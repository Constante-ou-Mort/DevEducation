using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;
using SeleniumTests.POM.AccountSettings;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class AccountSettingsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly AccountInfoPage _accountInfoPage;

        public AccountSettingsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _accountInfoPage = new AccountInfoPage(_webDriver);
        }

        [Given(@"Client is created and authorized")]
        public void GivenClientIsAuthorized()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE" },
                { "phone_number", "3453453454" }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{createdUser.TokenData.Token}');");

            _scenarioContext.Add(Context.User, createdUser);
        }

        [Given(@"Account Settings page is opened")]
        public void GivenAccountSettingsPageIsOpened()
        {
            _accountInfoPage.OpenPage();
        }

        [When(@"I click on edit password button on Account Settings page")]
        public void WhenIClickEditPasswordButtonOnAccountSettingsPage()
        {
            _accountInfoPage.ClickPasswordEditButton();
        }

        [When(@"I input client '(.*)' at Current password field in the Password Edit Block")]
        public void WhenIInputPasswordEditPasswordBlock(string currentPassword)
        {
            _accountInfoPage.SetCurrentPasswordEditPasswordBlock(currentPassword);
        }

        [When(@"I input new password '(.*)' at New password field in the Password Edit Block")]
        public void WhenIInputNewPasswordEditPasswordBlock(string newPassword)
        {
            _accountInfoPage.SetNewPasswordEditPasswordBlock(newPassword);
        }

        [When(@"I input new password '(.*)' at New password confirm field in the Password Edit Block")]
        public void WhenIInputNewPasswordConfirmEditPasswordBlock(string newPasswordConfirm)
        {
            _accountInfoPage.SetNewPasswordConfirmEditPasswordBlock(newPasswordConfirm);
        }

        [When(@"I click Save changes button at at the Edit Password Block")]
        public void WhenIClickEditPasswordBlockSubmitButton()
        {
            _accountInfoPage.ClickSaveChangesButtonEditPasswordBlock();
        }

        [Then(@"I see error message '(.*)' on the Account Settings page")]
        public void WhenIInputInvalidEmail(string message)
        {
            Assert.AreEqual(message, _accountInfoPage.SeeNotificationMessageInvalidOldPassword());
        }
    }
}
