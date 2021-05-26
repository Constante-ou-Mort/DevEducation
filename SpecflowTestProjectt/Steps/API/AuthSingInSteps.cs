using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class AuthSingInSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AuthSingInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", Constants.FirstName},
                {"last_name", Constants.LastName},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Context.User, createUser);
        }

        [Given(@"Client is created with added profile information")]
        public void GivenClientIsCreatedWithProfileInfo()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", Constants.FirstName},
                {"last_name", Constants.LastName},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            createUser.User.ClientProfile.Industry = Constants.Industry;
            createUser.User.ClientProfile.LocationName = Constants.LocationName;
            createUser.User.ClientProfile.LocationTimezone = Constants.LocationTimezone;

            _scenarioContext.Add(Context.User, createUser);
        }
    }
}