using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{

    public class PracticeFirstPart : IDisposable
    {
        private readonly ITestOutputHelper output;

        public PracticeFirstPart(ITestOutputHelper output)
        {
            this.output = output;
            this.output.WriteLine("Init execution...");
        }
        //[Fact]
        [Fact(DisplayName = "HR-Strings")]
        [Trait("Category", "Strings")]
        public void StringPractice()
        {
            HumanResources humanResource1 = new("Anna", "Clarence");
            HumanResources humanResource2 = new("LIZ", "flower");
            HumanResources humanResource3 = new("john", "CLARK");
            HumanResources humanResource4 = new("Pepe", "");

            Assert.True(humanResource1.Name.Equals("Anna"), $"Manager Name: {humanResource1.Name}");
            Assert.Equal("Anna Clarence", humanResource1.FullName, ignoreCase: true);
            Assert.NotEqual("Eliana", humanResource1.Name);
            Assert.StartsWith("An", humanResource1.Name);
            Assert.EndsWith("ce", humanResource1.FullName);

            Assert.Matches("[A-Z]{3} [a-z]{6}", humanResource2.FullName);
            Assert.Matches("[a-z]{4} [A-Z]{5}", humanResource3.FullName);

            Assert.True(string.IsNullOrWhiteSpace(humanResource4.LastName));
        }

        [Fact(DisplayName = "HR-Numeric")]
        [Trait("Category", "Strings")]
        public void NumericPractice()
        {
            Rest rest = new();
            Assert.True(rest.RandomNumber() is >= 600 and <= 700, $"Random Number {rest.RandomNumber()}");
        }

        [Fact(DisplayName = "HR-Double")]
        [Trait("Category", "Strings")]
        public void DoublePractice()
        {
            Rest rest = new();
            Assert.Equal(5.378, rest.RestDouble(15.6671, 10.2892), 3);
        }

        [Fact(DisplayName = "HR-Collection")]
        [Trait("Category", "Strings")]
        public void CollectionPractice()
        {
            Company company = new();
            Enginer enginer1 = new("Eliana", "Navia");
            Enginer enginer2 = new("Juan", "Lopez");
            Manager manager1 = new("Zeila", "Benavidez");
            Manager manager2 = new("Pepito", "Perez");
            HumanResources humanR1 = new("Alison", "Flower");
            HumanResources humanR2 = new("Ron", "Koniseg");
            HumanResources humanR3 = new("John", "Clark");

            List<Worker> workersList = new()
            {
                manager1,
                manager2,
                enginer1,
                enginer2
            };

            List<HumanResources> hrList = new()
            {
                humanR1,
                humanR2,
                humanR3
            };

            company.Workers = new List<Worker>
            {
                //manager1, manager2, enginer1, enginer2,
                humanR1, humanR2, humanR3
            };
            Assert.Equal(hrList, company.Workers);

            Assert.Contains(humanR1, company.Workers);
            Assert.Contains(humanR2, company.Workers);
            Assert.Contains(humanR3, company.Workers);

            Assert.DoesNotContain(humanR1, workersList);
            Assert.DoesNotContain(humanR2, workersList);

            enginer1.Salary = "1800"; enginer2.Salary = "1800";
            manager1.Salary = "2000"; manager2.Salary = "3000";
            humanR1.Salary = "1200"; humanR2.Salary = "1300"; humanR3.Salary = "1400";

            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrWhiteSpace(worker.Salary)));

            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Flower"));
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Koniseg"));
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Clark"));

            

        }

        [Fact(DisplayName = "HR-Objects")]
        [Trait("Category", "Objects")]
        public void ObjecPractice()
        {
            
           Company company = new();
                
           HumanResources humanR1 = new("Alison", "Flower");
           HumanResources humanR2 = new("Ron", "Koniseg");
           HumanResources humanR3 = new("John", "Clark");

           List<HumanResources> hrList = new()
           {
               humanR1,
               humanR2,
               humanR3
           };
            //Practice 1 - Second Part

            //-A HR instance is HumanResource type.
            Assert.IsType<HumanResources>(humanR1);
            //-A HR instance is not Manager type.
            Assert.IsNotType<Manager>(humanR1);
            //-A HR instance is assignable fromWorker.
            Assert.IsAssignableFrom<Worker>(humanR1);
            //-2 HR instances are not same.
            Assert.NotSame(humanR1, humanR2);
        }

        [Fact(DisplayName = "Null Exception Test")]
        [Trait("Category", "Null")]
        public void NullTest()
        {
            HumanResources humanR1 = new("Juanito", "Nieves");
            humanR1 = null;

            Assert.Throws<NullReferenceException>(() => humanR1.HRIsNull(humanR1));
        }
        public void Dispose()
        {
            output.WriteLine("Cleaning code ...");
        }
    }
}
