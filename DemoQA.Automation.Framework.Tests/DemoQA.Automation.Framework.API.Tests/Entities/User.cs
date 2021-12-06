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

        public List<Book> collectionOfIsbns { get; set; }
    }
}
