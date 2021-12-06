using RestSharp;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class RequestTests : AutomationTestBaseAPI
    {

        private readonly RestClient Client;

        public RequestTests()
        {
            Client = this.RestClient;
        }

        [Fact]

        public void GetBook()
        {
            RestRequest request = this.Fixture.GetBookRequest;
            request.AddParameter("ISBN", "9781449325862");
            IRestResponse response = Client.Execute<Book>(request);
            Assert.True(response.IsSuccessful);
            Assert.Equal(Response.OK, response.StatusCode.ToString());
            Assert.Equal(Response.Completed, response.ResponseStatus.ToString());
        }

        [Fact]

        public void GetBooks()
        {
            RestRequest request = this.Fixture.GetBooksRequest;
            IRestResponse queryResult = this.Client.Execute(request);
            Assert.True(queryResult.IsSuccessful);
        }
    }
}
