using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Features
{
    [Binding]
    public class RegistrationApiRequestSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public RegistrationApiRequestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Create client using POST method registration/registration-client with valid data")]
        public void GivenCreateClientUsingPOSTMethodRegistrationRegistration_ClientWithValidData()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Constants.User, createdUser);
        }
    }
}
