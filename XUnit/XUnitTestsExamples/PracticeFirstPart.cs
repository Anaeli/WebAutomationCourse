using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
        [Fact]
        public void Booleans()
        {
            HumanResource hr = new("Johnny", "Nitro", "3000");
            // Test to validate that HR FullName contains its name
            Assert.True(hr.Name.Equals("Johnny"), $"HR representant's name: {hr.Name}");
        }

        [Fact]
        public void Strings()
        {
            HumanResource hr = new("Johnny", "Quest", "3000");
            Assert.Equal("Johnny Quest", hr.FullName, true); // Use Assert.Equal to validate that FullName of  a HR is the expected.
            Assert.StartsWith("Jo", hr.Name); // Test to validate that HR name starts with the first 2 characters of its name.
            Assert.EndsWith("st", hr.FullName); // Test to validate that HR name ends with the lasts 2 characters of its name.
            Assert.Equal("QuEsT", hr.LastName, ignoreCase: true); // Have a HR instance with name in uppercase y lastname in lowercase, use ignore case to validate HR LastName.
            HumanResource hr2 = new("elmer", "FuDD", "3000");
            Assert.Matches("[a-z]+ [A-Z]+", hr2.FullName); // Have a HR instance with name in lowercase y lastname in uppercase, and create a regular expression to validate its FullName.
            HumanResource hr3 = new("elmer", "", "3000");
            Assert.Empty(hr3.LastName); // Use Assert.Empty to validate that HR LastName is empty.
        }

        [Fact]
        public void Numbers()
        {
            Rest rest = new();
            Addition addition = new();
            Assert.Equal(5, rest.SubstractInt(10, 5)); // Test to validate that expect result of a rest is correct.
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}"); // Change RandomNumber method in Addition class to return numbers between 600 - 700 and write validation for this change.
            Assert.Equal(10.8888, rest.SubstractDouble(10.9999, 0.1111), 3); // Test to validate that the result of a rest of two double number is correct, use 3 as floating precision number. Note: the decimal part of result number should have at least 4 numbers.
        }

        [Fact]
        public void CollectionsValidations()
        {
            Company company = new();
            HumanResource hr = new("Laura", "Bozzo", "3400");
            HumanResource hr1 = new("Jerry", "Springer", "3500");
            HumanResource hr2 = new("Cristina", "Saralegui", "3900");
            HumanResource hr3 = new("Geraldo", "Rivera", "4200");
            HumanResource hr4 = new("Johnny", "Thunder", "3800");

            List<Worker> workersList = new()
            {
                hr,
                hr1,
                hr2,
                hr3,
                // hr4
            };

            company.Workers = new List<Worker>
            {
                hr,
                hr1,
                hr2,
                hr3
            };

            Assert.Equal(workersList, company.Workers); // Test to validate that "hrList" is equal to "workers" list.
            Assert.Contains(hr1, company.Workers); // Test to validate that a HR member exist in "workers" list.
            Assert.DoesNotContain(hr4, company.Workers); // Test to validate that "workers" list does not contain a HR member.
            Assert.Contains(workersList, worker => worker.LastName.Contains("Bozzo")); // Test to validate if "workers" list contains a HR member according its LastName.
            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrWhiteSpace(worker.Salary))); // Set the salary of all members of "workers" list, and create a test case to validate that all salaries have been updated (worker.Salary is not empty).
        }
    }
}
