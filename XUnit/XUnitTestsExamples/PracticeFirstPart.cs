using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart :  IDisposable
    {
        private ITestOutputHelper testOutputHelper;
        HumanResource humanResource;
        HumanResource humanResource2;
        HumanResource humanResource3;
        HumanResource humanResource4;
        Rest restInt = new();
        Rest restDouble = new();
        Addition addition = new();
        List<HumanResource> HumanResources = new();
        Company company = new();

        public PracticeFirstPart(ITestOutputHelper outputHelper)
        {
            this.testOutputHelper = outputHelper;
            this.testOutputHelper.WriteLine("Init execution in class PracticeFirstPart");
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

        [Fact(DisplayName = "HRFullNameContainsItsName")]
        [Trait("Operation", "VerifyStrings")]
        public void TestFullNameContainsItsName()
        {
            this.testOutputHelper.WriteLine("Test FullNameContainesItsName");            
            Assert.True(humanResource.FullName.Contains("Copa"), $"HR Full Name is: {humanResource.FullName}");
        }

        [Fact(DisplayName = "HRStrings")]
        [Trait("Operation", "VerifyStrings")]
        public void TestValidateStrings()
        {
            Assert.Equal("Dayci Copa", humanResource.FullName);
            Assert.StartsWith("Da", humanResource.Name);
            Assert.EndsWith("ci", humanResource.Name);

            Assert.Equal("Garcia", humanResource2.LastName, ignoreCase: true);
            Assert.Matches("[a-z]+ [A-Z]", humanResource3.FullName);
            Assert.Empty(humanResource4.LastName);
        }

        [Fact(DisplayName = "HRNumbers")]
        [Trait("Operation", "VerifyNumbers")]
        public void TestValidateNumbers()
        {
            Assert.Equal(5, restInt.RestInt(10, 5));
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            Assert.Equal(5.611, restDouble.RestDouble(10.989, 5.378), 4);

        }

        [Fact(DisplayName = "HRCollections")]
        [Trait("Operation", "VerifyCollections")]
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

        [Fact(DisplayName = "HRObject")]
        [Trait("Operation", "VerifyObjects")]
        public void TestObjetType()
        {
            Assert.IsType<HumanResource>(humanResource);
            Assert.IsNotType<Manager>(humanResource);
            Assert.IsAssignableFrom<Worker>(humanResource2);
            Assert.NotSame(humanResource, humanResource2);

            HumanResource humanNull = new(null, null);
            Assert.Throws<ArgumentNullException>(() => humanNull.isAHRValid());
        }

        public void Dispose()
        {
            testOutputHelper.WriteLine("Cleanding code...");
        }
    }
}
