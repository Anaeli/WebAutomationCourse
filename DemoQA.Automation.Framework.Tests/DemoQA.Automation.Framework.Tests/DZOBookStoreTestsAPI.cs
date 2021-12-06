using DemoQA.Automation.Framework.Tests.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class DZOBookStoreTestsAPI
    {

        private readonly RestClient client;
        private User apiUser;

        public DZOBookStoreTestsAPI()
        {
            client = new RestClient("https://demoqa.com");
            apiUser = new User();
        }

       
        public void PostUser()
        {
            User user = new User
            {
                userName = "Dan",
                password = "Control123!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = client.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;
            apiUser.userName = userResult.userName;
            apiUser.password = user.password;
           
        }

        public void DeleteBook()
        {
            RestClient client = new RestClient("https://demoqa.com");
            client.Authenticator = new HttpBasicAuthenticator(apiUser.userName, apiUser.password);
            var request = new RestRequest("/BookStore/v1/Book", Method.DELETE);
            Book book = new Book
            {
                isbn = "9781449325862"
            };

            User user = new User
            {
                userId = apiUser.userId
            };

            RelationshipBookUser bookUser = new RelationshipBookUser
            {
                userId = user.userId,
                isbn = book.isbn
            };
            request.AddJsonBody(bookUser);
            IRestResponse queryResult = client.Execute(request);
          
        }
        public void PostBooks()
        {
            client.Authenticator = new HttpBasicAuthenticator(apiUser.userName, apiUser.password);
            var request = new RestRequest("/BookStore/v1/Books", Method.POST);

            Book book1 = new Book
            {
                isbn = "9781449325862"
            };

            Book book2 = new Book
            {
                isbn = "9781449331818"
            };

            Book book3 = new Book
            {
                isbn = "9781449337711"
            };
            Book book4 = new Book
            {
                isbn = "9781449365035"
            };
            Book book5 = new Book
            {
                isbn = "9781491904244"
            };
            Book book6 = new Book
            {
                isbn = "9781593275846"
            };
            Book book7 = new Book
            {
                isbn = "9781593277574"
            };

            User user = new User
            {
                //userId = apiUser.userId,
                userId = apiUser.userId,
                collectionOfIsbns = new List<Book>()
                {
                    book1,
                    book2,
                    book3,
                    book4,
                    book5,
                    book6,
                    book7,
                }
            };

            request.AddJsonBody(user);
            IRestResponse queryResult = client.Execute(request);
            //Assert.True(queryResult.IsSuccessful, "The request finished with errors");
            //Assert.Equal("Created", queryResult.StatusCode.ToString());
            //Assert.Equal("Completed", queryResult.ResponseStatus.ToString());
        }
    }       
}
