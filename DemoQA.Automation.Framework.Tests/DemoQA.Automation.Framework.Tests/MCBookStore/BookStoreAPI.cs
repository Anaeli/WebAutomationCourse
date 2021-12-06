using DemoQA.Automation.Framework.Tests.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class BookStoreAPI
    {
        private readonly RestClient client;
        private User apiUser;

        public BookStoreAPI()
        {
            client = new RestClient("https://demoqa.com");
            apiUser = new User();
        }

        //This method will be used in all BookStore tests
        [Fact]
        public void PostUser()
        {            
            User user = new User
            {
                userName = "TandyMiller",
                password = "Contr0l-123*/"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = client.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;
            apiUser.userName = userResult.userName;
            apiUser.password = user.password;
        }
    }
}
