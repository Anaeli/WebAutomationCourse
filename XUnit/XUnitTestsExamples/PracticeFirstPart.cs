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
        
        [Fact]
        public void Boolean()
            {
            HumanResources HR = new("Maria", "Galindo");
            HumanResources HR1 = new ("MARIA", "galindo");
            HumanResources HR2 = new("MARIA", "");
            HumanResources HR3 = new("maria", "GALINDO");

            // Test to validate that HR FullName contains its name string.
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", HR.FullName);
            //User Assert.Equal to validate that FullName of a HR is the expected.
            Assert.Equal("Maria Galindo", HR.FullName);
            //Test to validate that HR name start with ther fisrt 2 characters of its name.
            Assert.Contains("Ma", HR.Name);
            //Test to validate that HR name ends with the last 2 characters of its name.
            Assert.EndsWith("ia", HR.Name);     
            //Have a HR instance with name in uppercase y lastname in lowercase, use ignore case to validate HR LastName
            Assert.Equal("MARIA galindo", HR1.FullName, ignoreCase: HR1.LastName.Contains("galindo")); 
            //Have a HR instance with name in lowercase y lastname in uppercase, and create a regular expression to validate its FullName
            Assert.True(HR3.Name.Equals("maria") && HR3.LastName.Equals("GALINDO"), $"HR FullName: {HR3.FullName}");
            //Use Assert.Empty to validate that HR LastName is empty
            Assert.Empty(HR2.LastName);
        }
        [Fact]
        public void Numbers()
        {
            Rest rest = new();
            Addition addition = new();

            // Test to validate that expect result of a rest is correct
            Assert.Equal(5, rest.restInteger(10,5));
            //Change RandomNumber method in Addition class to return numbers between 600 - 700 and write validation for this change
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            Assert.InRange<int>(addition.RandomNumber(), 600, 700);
        }
        [Fact]
        public void Double()
        {
            Rest rest = new();

            //Test to validate that the result of a rest of two double number is correct, use 3 as floating precision number.
            Assert.Equal(6.293, rest.restDouble(9.4475, 3.1546),3);
        }
        [Fact]
        public void Colletion()
        {   
            //Create a collection with HR members (hrList), add HR members to company "workers" list.
            
            Company company = new();

            HumanResources HR1 = new("Marcos","Fernandez");
            HumanResources HR2 = new("Gabriela", "Lopez");
            HumanResources HR3 = new("Jose", "Chambi");
            HumanResources HR4 = new("Lupe","Sanchez");

            List<HumanResources> hrList = new()
            { 
                HR1,
                HR2,
                HR3
            };

            company.Workers = new List<Worker>
            {
                HR1,
                HR2,
                HR3
            };

            //Test to validate that "hrList" is equal to "workers" list.
            Assert.Equal(hrList, company.Workers);
            //Test to validate that a HR member exist in "workers" list.
            Assert.Contains(HR2, company.Workers);
            //Test to validate "workers" list doest not contain a HR member.
            Assert.DoesNotContain(HR4, company.Workers);
            //Test to validate if "workers" list contains a HR member according its LastName.
            Assert.Contains(company.Workers, worker => worker.LastName.Contains("Lopez"));
            //Set the salary of all members of "workers" list, and create a test case to validate that all salaries have been update (worker.salary is not empty)
            HR1.Salary = "1200";
            HR2.Salary = "1400";
            HR3.Salary = "1600";

           Assert.All(company.Workers, worker => Assert.False(string.IsNullOrWhiteSpace(worker.Salary)));
        }
    }
}
