using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class HelloWorld : IDisposable
    {
        private readonly ITestOutputHelper output;

        public HelloWorld(ITestOutputHelper output)
        {
            this.output = output;
            this.output.WriteLine("Init execution...");
        }

        [Fact]
        public void FirstTest()
        {
            this.output.WriteLine("first test...");
            Manager manager = new("Zeila", "Benavidez");
            Assert.True(manager.Name.Equals("Zeila"), $"Manager Name: {manager.Name}");
            Assert.True(manager.FullName.Contains("Zeila"), $"Manager Name: {manager.Name}");       
            Assert.Equal("ZEILA BENAVIDEZ", manager.FullName, ignoreCase: true);
            Assert.NotEqual("Eliana", manager.Name);
            Assert.Contains("la Be", manager.FullName);
            Assert.StartsWith("Z", manager.Name);
            Assert.EndsWith("Benavidez", manager.FullName);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", manager.FullName);

            manager.LastName = string.Empty;
            Assert.Empty(manager.LastName);
        }

        [Fact(DisplayName = "TestInt")]
        [Trait("Category", "Operations")]
        [Trait("Operations", "Int")]
        public void Numeric()
        {
           
            Addition addition = new();
            Assert.Equal(15, addition.AddInt(5, 10));
            Assert.True(addition.RandomNumber(1, 101) is >= 1 and <= 100, $"Random Number {addition.RandomNumber(1,101)}");
            Assert.InRange<int>(addition.RandomNumber(1,101), 1, 100);
        }

        [Fact]
        [Trait("Category", "Operations")]
        [Trait("Operations", "Double")]
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
            foreach(var worker in company.Workers)
            {
                worker.Salary ="1000";
            }
            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrEmpty(worker.Salary)));

        }


        [Fact]
        public void TestExceptions()
        {
            Enginer enginer1 = new("Eliana", "Navia");
            Assert.Throws<ArgumentNullException>(() => enginer1.GetSalary());
        }

        [Fact]
        public void TestEvent()
        {
            Enginer enginer1 = new("Eliana", "Navia");
            Assert.Raises<EventArgs>(
                handler => enginer1.WorkHours += handler,
                handler => enginer1.WorkHours -= handler,
                () => enginer1.WorkedHours());
        }

        [Fact]
        public void TestObjetType()
        {
            Enginer enginer1 = new("Eliana", "Navia");
            Enginer enginer2 = new("Juan", "Lopez");
            Assert.IsType<Enginer>(enginer1);
            //Assert.IsType<Manager>(enginer1);
            Assert.IsNotType<DateTime>(enginer1);
            Assert.IsAssignableFrom<Worker>(enginer1);
            Assert.NotSame(enginer1, enginer2);
            Assert.IsNotType<Manager>(enginer1);
        }

        public void Dispose()
        {
            output.WriteLine("Cleaning code...");
        }
    }
}
