using System.Collections.Generic;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class PracticeFirstPart
    {
        [Fact]
        public void Boolean()
        {
            // Validate FullName contains its name
            HumanResource hr = new("Fernando", "Sivila");
            Assert.True(hr.Name.Equals("Fernando"), $"HR representant's name: {hr.Name}");
        }

        [Fact]
        public void String()
        {
            HumanResource hr = new("Juan", "Perez");
            // Use Assert.Equal to validate that FullName of  a HR is the expected.
            Assert.Equal("Juan Perez", hr.FullName, true);
            // Test to validate that HR name starts with the first 2 characters of its name.
            Assert.StartsWith("Ju", hr.Name);
            // Test to validate that HR name ends with the lasts 2 characters of its name.
            Assert.EndsWith("an", hr.Name);
            // Have a HR instance with name in uppercase y lastname in lowercase, use ignore case to validate HR LastName.
            HumanResource hr2 = new("MARIA", "gomez"); 
            Assert.Equal("gomez", hr2.LastName, ignoreCase: true);
            // Have a HR instance with name in lowercase y lastname in uppercase, and create a regular expression to validate its FullName.
            HumanResource hr3 = new("pablo", "MAMANI");
            Assert.Matches("[a-z]+ [A-Z]+", hr3.FullName);
            // Use Assert.Empty to validate that HR LastName is empty.
            HumanResource hr4 = new("Pedro", "");
            Assert.Empty(hr4.LastName); 
        }

        [Fact]
        public void Numbers()
        {
            // Test to validate that expect result of a rest is correct.
            Rest rest = new();
            Assert.Equal(14, rest.RestInt(28, 14));
            // Change RandomNumber method in Addition class to return numbers between 600 - 700 and write validation for this change.
            Addition addition = new();
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            // Test to validate that the result of a rest of two double number is correct, use 3 as floating precision number. Note: the decimal part of result number should have at least 4 numbers.
            Assert.Equal(15.001, rest.RestDouble(18.1244, 3.1234), 3); 
        }

        [Fact]
        public void Collections()
        {
            Company company = new();
            HumanResource hr = new("Jaime", "Arze");
            HumanResource hr1 = new("Alvaro", "Luna");
            HumanResource hr2 = new("Cristian", "Martinez");
            HumanResource hr3 = new("Martin", "Siles");
            HumanResource hr4 = new("Alberto", "Gonzales");

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
            // Test to validate that "hrList" is equal to "workers" list.
            Assert.Equal(workersList, company.Workers);
            // Test to validate that a HR member exist in "workers" list.
            Assert.Contains(hr1, company.Workers);
            // Test to validate that "workers" list does not contain a HR member.
            Assert.DoesNotContain(hr4, company.Workers);
            // Test to validate if "workers" list contains a HR member according its LastName.
            Assert.Contains(workersList, worker => worker.Name.Contains("Martin"));
            // Set the salary of all members of "workers" list, and create a test case to validate that all salaries have been updated (worker.Salary is not empty).
            hr.Salary = "4000";
            hr1.Salary = "4500";
            hr2.Salary = "5000";
            hr3.Salary = "5500";
            hr4.Salary = "6000";

            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrEmpty(worker.Salary)));
        }
    }
}