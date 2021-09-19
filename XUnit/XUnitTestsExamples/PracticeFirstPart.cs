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

        [Fact(DisplayName = "HRBooleans")]
        [Trait("Category", "Booleans")]
        public void HRBooleanTests()
        {
            HumanResource myHR = new("Lizel", "Garcia");
            Assert.True(myHR.FullName.Contains("Lizel"), $"HR Full Name is: {myHR.FullName}");
        }

        [Fact(DisplayName = "HRStrings")]
        [Trait("Category", "Strings")]
        public void HRStringTests()
        {
            HumanResource myHR = new("Lizel", "Garcia");
            Assert.Equal("Lizel Garcia", myHR.FullName, ignoreCase: true);
            Assert.StartsWith("Li", myHR.Name);
            Assert.EndsWith("el", myHR.Name);
            
            HumanResource mySecondHR = new("Lizel".ToUpper(), "Garcia".ToLower());
            Assert.Equal("Garcia", mySecondHR.LastName, ignoreCase: true);

            HumanResource myThirdHR = new("Lizel".ToLower(), "Garcia".ToUpper());
            Assert.Matches("[a-z]+ [A-Z]", myThirdHR.FullName);
        }

        [Fact(DisplayName = "HRNumerics")]
        [Trait("Category", "Numerics")]
        public void HRNumericTests()
        {
            this.output.WriteLine("Starting Substraction integer tests..");
            Rest substraction = new();
            Assert.Equal(58, substraction.substractIntegerNumbers(100, 42));
            Addition addition = new();
            int randomNumber = addition.RandomNumber();
            Assert.True(randomNumber is >= 600 and <= 700, $"Random Value was: {randomNumber}");
            this.output.WriteLine("Substraction integer tests are complete.");
        }

        [Fact(DisplayName = "HRDoubles")]
        [Trait("Category", "Doubles")]
        public void HRDoubleTests()
        {
            this.output.WriteLine("Starting Substraction double tests..");
            Rest substraction = new();
            Assert.Equal(58.2474, substraction.substractDoubleNumbers(100.25350, 42.00610), 3);
            this.output.WriteLine("Substraction double tests are complete.");
        }

        [Fact(DisplayName = "HRCollections")]
        [Trait("Category", "Collections")]
        public void HRCollectionTests()
        {
            List<HumanResource> hrList = new();
            HumanResource hr1 = new("Lizel", "Garcia");
            HumanResource hr2 = new("Georgina", "Valverde");
            HumanResource hr3 = new("Monica", "Messa");
            HumanResource hr4 = new("Cintya", "Olivera");

            hrList.Add(hr1);
            hrList.Add(hr2);
            hrList.Add(hr3);
            hrList.Add(hr4);

            Company company = new();
            company.Workers = new List<Worker>{ hr1, hr2, hr3, hr4 };

            Assert.Equal(hrList, company.Workers);
            Assert.Contains(hr1, company.Workers);
            Assert.DoesNotContain(new HumanResource("Francisco", "De Los Palotes"), company.Workers);
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Garcia"));
            foreach (HumanResource hr in hrList) {hr.Salary = "50.25"; }
            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrEmpty(worker.Salary)));
        }

        [Fact(DisplayName = "HRObjectTypes")]
        [Trait("Category", "Objects")]
        public void HRObjectTypeTests()
        {
            HumanResource hr1 = new("Lizel", "Garcia");
            Assert.IsType<HumanResource>(hr1);
            Assert.IsNotType<Manager>(hr1);
            Assert.IsAssignableFrom<Worker>(hr1);

            HumanResource hr2 = new("Georgina", "Valverde");
            Assert.NotSame(hr1, hr2);

            HumanResource hr3 = null;
            Assert.Throws<NullReferenceException>(() => hr3.humanResourceExists(hr3));
            this.output.WriteLine("Using NullReferenceException");

            HumanResource hr4 = new(null, null);
            Assert.Throws<ArgumentNullException>(() => hr4.humanResourceExists());
            this.output.WriteLine("Using ArgumentNullException");
        }

        [Theory]
        [InlineData(100, 42, 58)]
        [InlineData(100, 50, 50)]
        public void substractNumbersInlineTests(int a, int b, int expected)
        {
            Rest substraction = new();
            int result = substraction.substractIntegerNumbers(a, b);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Data driven - Internal Substraction Data")]
        [MemberData(nameof(InternalSubstractionData.SubstractionTestData),
         MemberType = typeof(InternalSubstractionData))]
        public void substractNumbersinternalDataDrivenTests(int num1, int num2, int expectResult)
        {
            Rest substraction = new();
            int actualResult = substraction.substractIntegerNumbers(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalSubstractionData.SubstractionTestData),
         MemberType = typeof(ExternalSubstractionData))]
        public void substractNumbersExternalDataDriven(int num1, int num2, int expectResult)
        {
            Rest substraction = new();
            int actualResult = substraction.substractIntegerNumbers(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - DataAttribute")]
        [SubstractionDataAttribute]
        public void substractNumbersDataAttributeTests(int num1, int num2, int expectedResult)
        {
            Rest substraction = new();
            int actualResult = substraction.substractIntegerNumbers(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        public void Dispose()
        {
            output.WriteLine("Cleaning code ...");
        }
    }
}
