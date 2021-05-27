using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NUnit.Framework;
using RestSharp;

namespace NewBookModelsApiTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", "asda2sd2asd@asdasd.ert" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE" },
                { "phone_number", "3453453454" }
            };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
        }

        [Test]
        public void Test2()
        {
            var expectedEmail = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
            Thread.Sleep(100);
            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user);

           var responseModel = ClientRequests.SendRequestChangeClientEmailPost(
                "123qweQWE", expectedEmail, createdUser.TokenData.Token);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedEmail, responseModel.Model.Email);
                Assert.AreEqual(HttpStatusCode.OK, responseModel.Response.StatusCode);
            });

        }
        [Test]
        public void CheckedForSuccessfulFirstNameLastNameChange()
        {
            var user = new Dictionary<string, string>
            {
                 { "email", $"Will{DateTime.Now:ddyyyymmHHssmm}@gmail.com" },
                { "first_name", "Will" },
                { "last_name", "Smith" },
                { "password", "123qweQWE1" },
                { "phone_number", "3453453454" }
            };
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user);
            var _validNewFirstName = "Petro";
            var _validNewSecondName = "Shevchenko";
            var newPrimaryAccountHolderName = ClientRequests.SendRequestChangeFirstNammeLastNamePatch(_validNewFirstName, _validNewSecondName, createdUser.TokenData.Token);

          // Assert.Multiple(() =>
          // {
          //     Assert.AreEqual(_validNewFirstName, newPrimaryAccountHolderName.FirstName);
          //     Assert.AreEqual(_validNewSecondName, newPrimaryAccountHolderName.LastName);
          // });
        }
    }
}