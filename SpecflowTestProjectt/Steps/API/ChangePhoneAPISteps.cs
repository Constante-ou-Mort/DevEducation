using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecflowTestProject.Steps.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    class ChangePhoneAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        public ChangePhoneAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        } 

        public string SendRequestChangePhoneNumberPost(string password, string newPhone, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneModel = new Dictionary<string, string>
            {
                { "phone_number", newPhone },
                { "password", password }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changedPhoneResponse = JsonConvert.DeserializeObject<ChangePhoneResponse>(response.Content);

            return changedPhoneResponse.Phone;
        }


        [When(@"I send POST request client/change_phone/ with new phone '(.*)'")]
        public void WhenISendValidChangeNumberReques(string phone)
        {
            var user = _scenarioContext.Get<ResponseModel<ClientAuthModel>>("Response");
            var responseNumberModel = SendRequestChangePhoneNumberPost("123qweQWE!", phone, user.Model.TokenData.Token);
            _scenarioContext.Add("Number Response", responseNumberModel);
        }

        [Then(@"User`s number changed")]
        public void ThenUsersEmailChanging()
        {
            var actualResult = _scenarioContext.Get<string>("Number Response");

            Assert.AreEqual("1111122222", actualResult);
        }
    }
}
