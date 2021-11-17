using DemoQA.Automation.Framework.API.Tests.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Xunit;

namespace DemoQA.Automation.Framework.API.Tests
{
    public class APITests
    {
        private readonly RestClient client;
        private User apiUser;

        public APITests()
        {
            client = new RestClient("https://demoqa.com");
            apiUser = new User();
        }

        [Fact]
        public void PostUser()
        {            
            User user = new User
            {
                userName = "Eli7",
                password = "Control123!!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = client.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;
            apiUser.userName = userResult.userName;
            apiUser.password = user.password;
            Assert.IsType<User>(userResult);
            Assert.Equal(user.userName, userResult.userName);
            Assert.True(queryResult.IsSuccessful);
            Assert.Equal("Created", queryResult.StatusCode.ToString());
            Assert.Equal("Completed", queryResult.ResponseStatus.ToString());
        }

        [Fact]
        public void PostBooks()
        {
            client.Authenticator = new HttpBasicAuthenticator("Eli7", "Control123!!");
            var request = new RestRequest("/BookStore/v1/Books", Method.POST);

            Book book1 = new Book
            {
                isbn = "9781449337711"
            };

            Book book2 = new Book
            {
                isbn = "9781449365035"
            };

            User user = new User
            {
                userId = apiUser.userId,
                collectionOfIsbns = new List<Book>()
                {
                    book1,
                    book2
                }
            };

            request.AddJsonBody(user);
            IRestResponse queryResult = client.Execute(request);
            Assert.True(queryResult.IsSuccessful, "The request finished with errors");
            Assert.Equal("Created", queryResult.StatusCode.ToString());
            Assert.Equal("Completed", queryResult.ResponseStatus.ToString());
        }

        [Fact]

        public void GetBook()
        {
            RestRequest request = new RestRequest("/BookStore/v1/Book", Method.GET, DataFormat.Json);
            request.AddParameter("ISBN", "9781449325862");
            IRestResponse response = client.Execute<Book>(request);
            Assert.True(response.IsSuccessful, "The request finished with errors");
            Assert.Equal("OK", response.StatusCode.ToString());
            Assert.Equal("Completed", response.ResponseStatus.ToString());
        }

        /// <summary>
        /// The book should be already added.
        /// </summary>
        [Fact]
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
            Assert.True(queryResult.IsSuccessful);
            Assert.Equal("NoContent", queryResult.StatusCode.ToString());
            Assert.Equal("Completed", queryResult.ResponseStatus.ToString());
        }

        [Fact]

        public void GetBooks()
        {
            var request = new RestRequest("/BookStore/v1/Books", Method.GET, DataFormat.Json);
            IRestResponse queryResult = client.Execute(request);
            Assert.True(queryResult.IsSuccessful);
        }
    }
}
