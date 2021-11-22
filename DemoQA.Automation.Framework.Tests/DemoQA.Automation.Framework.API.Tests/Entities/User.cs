using RestSharp;
using System.Collections.Generic;

namespace DemoQA.Automation.Framework.API.Tests
{
    public class User
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public List<Book> books { get; set; }
        private readonly RestClient client = new RestClient("https://demoqa.com");

        public List<Book> collectionOfIsbns { get; set; }

        public string AddUser(User user)
        {
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = this.client.Execute<User>(request);
            User userResult = queryResult.Data;
            this.userId = userResult.userId;
            this.userName = userResult.userName;
            this.password = user.password;
            IRestResponse<User> response = queryResult;
            return this.userId;
        }
    }
}
