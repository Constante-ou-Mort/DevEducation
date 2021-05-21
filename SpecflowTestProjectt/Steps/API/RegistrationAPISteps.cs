﻿using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class RegistrationAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        public RegistrationAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public static ResponseModel<ClientAuthModel> CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            var user = new Dictionary<string, string>
                {
                    { "email" , $"its{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                    { "first_name" , "Petter" },
                    { "last_name" ,"Parker" },
                    { "password" ,"123qweQWE!"},
                    { "phone_number" , "3453453454"}
                };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = createdUser, Response = response };
        }

        public class ResponseModel<T>
        {
            public T Model { get; set; }
            public IRestResponse Response { get; set; }
        }

        [When(@"I send valid registration request ")]
        public void WhenISendValidRegistrationReques()
        {
            var user = CreateUserViaApi();
        }
    }
}
