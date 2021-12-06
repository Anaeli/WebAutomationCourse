using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using RestSharp.Authenticators;
using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.BDD.API;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.BDD.Tests.MCBookStore
{
    public class BookStoreLoginTest : AutomationTestBase, IDisposable
    {
        //private readonly AutomationClient Client;

        //public BookStoreLoginTest(AutomationClient client, ITestOutputHelper output) : base(output)
        //{
        //    Client = client;
        //    User user = new User
        //    {
        //        userName = "Someone",
        //        password = "Contr0l-123*/"
        //    };

        //    string userID = user.AddUserByAPI(user);
        //}

        private readonly RestClient client;
        private User apiUser;

        public BookStoreLoginTest(ITestOutputHelper output) : base(output)
        {
            client = new RestClient("https://demoqa.com");
            apiUser = new User();
        }

        [Theory]
        [InlineData("Someone", "Contr0l-123*/")]

        public void AddUserStep(string name, string pass)
        {
            User user = new User
            {
                userName = name,
                password = pass
            };
        }


        public void Dispose()
        {
            apiUser.DeleteUserByUI(apiUser);
        }
        
    }
}
