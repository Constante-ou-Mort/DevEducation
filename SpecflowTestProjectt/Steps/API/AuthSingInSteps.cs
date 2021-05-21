using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class AuthSingInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;


        public AuthSingInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
        }

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Context.User, createUser);
            
        }

        [Given(@"Client is authorized")]
        public void GivenClientIsAuthorized()
        {
           _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
           IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;           
           js.ExecuteScript($"localStorage.setItem('access_token','{_scenarioContext.Get<ClientAuthModel>(Context.User).TokenData.Token}')");
        }
    }
}