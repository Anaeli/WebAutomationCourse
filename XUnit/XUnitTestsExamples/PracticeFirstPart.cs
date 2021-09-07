using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
        HumanResource humanResource;
        HumanResource humanResource2;
        HumanResource humanResource3;
        HumanResource humanResource4;
        Rest restInt = new();
        Rest restDouble = new();
        Addition addition = new();
        List<HumanResource> HumanResources = new();
        Company company = new();
        public PracticeFirstPart()
        {
            HumanResources.Add(this.humanResource = new("Dayci", "Copa"));
            HumanResources.Add(this.humanResource2 = new("Lizel".ToUpper(), "Garcia".ToLower()));
            HumanResources.Add(this.humanResource3 = new("Noelia".ToLower(), "Villaroel".ToUpper()));
            this.humanResource4 = new("Ana", "");
            company.Workers = new List<Worker>
            {
                humanResource,
                humanResource2,
                humanResource3
            };
        }

        [Fact]
        public void TestFullNameContainsItsName()
        {
            
            Assert.True(humanResource.FullName.Contains("Copa"), $"HR Full Name is: {humanResource.FullName}");
        }

        [Fact]
        public void TestValidateStrings()
        {
            Assert.Equal("Dayci Copa", humanResource.FullName);
            Assert.StartsWith("Da", humanResource.Name);
            Assert.EndsWith("ci", humanResource.Name);

            Assert.Equal("Garcia", humanResource2.LastName, ignoreCase: true);
            Assert.Matches("[a-z]+ [A-Z]", humanResource3.FullName);
            Assert.Empty(humanResource4.LastName);
        }

        [Fact]
        public void TestValidateNumbers()
        {
            Assert.Equal(5, restInt.RestInt(10, 5));
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            Assert.Equal(5.611, restDouble.RestDouble(10.989, 5.378), 4);

        }

        [Fact]
        public void TestValidateCollections()
        {
            Assert.Equal(HumanResources, company.Workers);
            Assert.Contains(humanResource2, company.Workers);
            Assert.DoesNotContain(humanResource4, company.Workers);
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Copa"));
            foreach (HumanResource human in HumanResources) 
            {
                human.Salary = "100";
            }
            Assert.All(company.Workers, worker => Assert.NotEmpty(worker.Salary));

        }
    }
}
