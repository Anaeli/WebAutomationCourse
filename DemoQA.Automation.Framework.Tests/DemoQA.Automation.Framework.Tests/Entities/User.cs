using RestSharp;
using System.Collections.Generic;

namespace DemoQA.Automation.Framework.Tests
{
    public class User
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public List<Book> books { get; set; }

        public List<Book> collectionOfIsbns { get; set; }

        //public string AddUserByAPI(User user)
        //{
        //    RestRequest request = this.Fixture.PostUserRequest;
        //    request.AddJsonBody(user);
        //    IRestResponse<User> queryResult = this.Client.Execute<User>(request);
        //    User userResult = queryResult.Data;
        //    IRestResponse<User> response = queryResult;
        //    return userId;
        //}

        public void DeleteUserByUI(User user)
        {

        }
    }
}
