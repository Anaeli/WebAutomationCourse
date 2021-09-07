using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class HelloWorld
    {
        [Fact]
        public void FirstTest()
        {
            Manager manager = new("Zeila", "Benavidez");
            Assert.True(manager.Name.Equals("Zeila"), $"Manager Name: {manager.Name}");
            Assert.Equal("ZEILA BENAVIDEZ", manager.FullName, ignoreCase: true);
            Assert.NotEqual("Eliana", manager.Name);
            Assert.Contains("la Be", manager.FullName);
            Assert.StartsWith("Z", manager.Name);
            Assert.EndsWith("Benavidez", manager.FullName);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", manager.FullName);
        }

        [Fact]
        public void Numeric()
        {
            Addition addition = new();
            Assert.Equal(15, addition.AddInt(5, 10));
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            Assert.InRange<int>(addition.RandomNumber(), 600, 700);
        }

        [Fact]
        public void Double()
        {
            Addition addition = new();
            Assert.Equal(15.667, addition.AddDouble(5.378, 10.289));
            Assert.Equal(15.67, addition.AddDouble(5.378, 10.289), 2);
        }

        [Fact]
        public void Collection()
        {
            Company company = new();
            Enginer enginer1 = new("Eliana", "Navia");
            Enginer enginer2 = new("Juan", "Lopez");
            Enginer enginer3 = new("Geralt", "Of Rivia");
            Manager manager1 = new("Zeila", "Benavidez");
            Manager manager2 = new("Pepito", "Perez");

            List<Worker> workersList = new()
            {
                manager1,
                manager2,
                enginer1,
                enginer2
            };

            company.Workers = new List<Worker>
            {
                manager1,
                manager2,
                enginer1,
                enginer2,
            };

            Assert.Equal(workersList, company.Workers);
            Assert.Contains(enginer1, company.Workers);
            Assert.DoesNotContain(enginer3, company.Workers);
            Assert.Contains(company.Workers, worker => worker.Name.Contains("Eliana"));
            Assert.All(company.Workers, worker => Assert.True(string.IsNullOrWhiteSpace(worker.Salary)));
        }
    }
}
