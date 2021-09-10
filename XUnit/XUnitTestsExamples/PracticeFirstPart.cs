using System;
using System.Collections.Generic;
using Xunit;
using XUnitTests;

namespace XUnitProject
{
    public class PracticeFirstPart
    {
        public PracticeFirstPart()
        {
        }

        [Fact]
        public void HRValidations()
        {
            var HR_Officer1 = new HumanResource("Alan", "Garcia");
            var HR_Officer2 = new HumanResource("pepito", "PEREZ");
            var HR_Officer3 = new HumanResource("ALBERTO", "badu");
            var HR_Officer4 = new HumanResource("JuanSinApellido", "");

            // Test to validate that HR FullName contains its name String
            Assert.Contains(HR_Officer1.Name, HR_Officer1.FullName);

            // Use Assert.Equal to validate that FullName of a HR is the expected
            Assert.Equal($"{HR_Officer1.Name} {HR_Officer1.LastName}", HR_Officer1.FullName);

            // Test to validate that HR name starts with the first 2 characters of its name
            Assert.StartsWith("Al", HR_Officer1.Name);

            // test to validate that HR name ends with the last 2 characters of its name
            Assert.EndsWith("an", HR_Officer1.Name);

            // Have an HR instance with name in uppercase and lastname in lowercase, use ignore case to validate HR LastName
            Assert.Equal("ALBERTO BADU", HR_Officer3.FullName, ignoreCase: true);

            // Have ah HR instance with name in lowercase and lastname in uppercase and create a regular expression to validate its FullName
            Assert.Matches("[a-z]+ [A-Z]+", HR_Officer2.FullName);

            // Use Assert.Empty to validate that HR lastName is empty
            Assert.Empty(HR_Officer4.LastName);

        }

        [Fact]
        public void NumbersValidation()
        {
            // Test to validate that expected result of a rest is correct
            var operation = new Rest();
            Assert.Equal(3, operation.RestNumbers(7, 4));

            // Change RandomNumber Method in Addition class to return numbers between 600 - 700 and write validation for this change
            var rnd = new Addition();
            var value = rnd.RandomNumber();
            Assert.True(value > 599 && value < 701, $"The value {value} was not in range");

        }

        [Fact]
        public void DoubleValidations()
        {
            // Test to validate that the result of a rest of two double number is correct, use 3 as floating precision number. Note: the decimal part of the result number should have at least 4 digits
            var operation = new Rest();
            Assert.Equal(5.864, operation.RestNumbers(12.9876, 7.1234), 3);
        }

        [Fact]
        public void CollectionsValidation()
        {
            // Create a collection with HR members (hrlist), add HR members to company "Workers" list.
            var HR_Officer1 = new HumanResource("Alan", "Garcia");
            var HR_Officer2 = new HumanResource("pepito", "PEREZ");
            var HR_Officer3 = new HumanResource("ALBERTO", "badu");
            var HR_Officer4 = new HumanResource("JuanSinApellido", "");

            List<HumanResource> hrlist = new()
            {
                HR_Officer1,
                HR_Officer3,
                HR_Officer4
            };

            var company = new Company();
            company.Workers = new List<Worker>
            {
                HR_Officer1, HR_Officer3, HR_Officer4
            };

            // Test to validate that "hrlist" is equal to "workers" list
            Assert.Equal(hrlist, company.Workers);

            // Test to validate that a HR member exist in "workers" list
            Assert.Contains(HR_Officer3, company.Workers);

            // Test to validate that "workers" list does not contain a HR member
            Assert.DoesNotContain(HR_Officer2, company.Workers);

            // Test to validate if "workers" list contains an HR member according to its LastName
            Assert.Contains(company.Workers, Worker => Worker.LastName.Contains("badu"));

            // Set the salary of all members of "workers" list and create a test case to validate that all salaries have been updated (worker.Salary is not empty)
            HR_Officer1.Salary = "2500";
            HR_Officer3.Salary = "2900";
            HR_Officer4.Salary = "3500";

            Assert.All(company.Workers, Worker => Assert.False(string.IsNullOrEmpty(Worker.Salary)));

        }
    }
}
