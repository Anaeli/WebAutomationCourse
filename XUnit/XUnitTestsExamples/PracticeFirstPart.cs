using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
        [Fact]
        public void HRBooleanTests()
        {
            HumanResource myHR = new("Lizel", "Garcia");
            Assert.True(myHR.FullName.Contains("Lizel"), $"HR Full Name is: {myHR.FullName}");
        }

        [Fact]
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

        [Fact]
        public void HRNumericTests()
        {
            Rest substraction = new();
            Assert.Equal(58, substraction.substractIntegerNumbers(100, 42));
            Addition addition = new();
            int randomNumber = addition.RandomNumber();
            Assert.True(randomNumber is >= 600 and <= 700, $"Random Value was: {randomNumber}");
        }

        [Fact]
        public void HRDoubleTests()
        {
            Rest substraction = new();
            Assert.Equal(58.2474, substraction.substractDoubleNumbers(100.25350, 42.00610), 3);
        }

        [Fact]
        public void HRCollectionTests()
        {
            /*
              - Create a collection with HR members (hrList), add HR members to company "workers" list.
              - Test to validate that "hrList" is equal to "workers" list.
              - Test to validate that a HR member exist in "workers" list.
              - Test to validate that  "workers" list does not contain a HR member.
              - Test to validate if  "workers" list contains a HR member according its LastName.
             -  Set the salary of all members of "workers" list, and create a test case to validate that all salaries have been updated (worker.Salary is not empty).
            */

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
    }
}
