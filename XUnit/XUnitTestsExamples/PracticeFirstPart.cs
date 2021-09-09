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
            HumanResource humrec = new("Julio", "Verne");
            Assert.True(humrec.Name.Equals("Julio"), $"HR employee name: {humrec.Name}");
        }

        [Fact]
        public void Strings()
        {
            HumanResource humrec = new("Julio", "Estevez");            
            Assert.Equal("Julio Estevez", humrec.FullName, true);
            Assert.StartsWith("Ju", humrec.Name);
            Assert.EndsWith("io", humrec.Name);            
            HumanResource humrec2 = new("MIGUEL", "arias");
            Assert.Equal("arias", humrec2.LastName, ignoreCase: true);
            HumanResource humrec3 = new("paola", "IDALGO");
            Assert.Matches("[a-z]+ [A-Z]+", humrec3.FullName);           
            HumanResource humrec4 = new("Cesar", "");
            Assert.Empty(humrec4.LastName);
        }

        [Fact]
        public void Numbers()
        {
            Rest rest = new();
            Addition addition = new();
            Assert.Equal(2, rest.SubstractInt(9, 7));
            Assert.True(addition.RandomNumber() is >= 600 and <= 700, $"Random Number {addition.RandomNumber()}");
            Assert.Equal(4, rest.SubstractDouble(4.025, 0.025), 3);
        }

        [Fact]
        public void CollectionsValidations()
        {
            Company company = new();
            HumanResource humrec = new("Jerry", "Rivera");
            HumanResource humrec1 = new("Miguel", "Bose");
            HumanResource humrec2 = new("Ricardo", "Montalvan");
            HumanResource humrec3 = new("Julio", "Borges");
            HumanResource humrec4 = new("Gabriel", "Garcia");

            List<Worker> workersList = new()
            {
                humrec, humrec1, humrec2, humrec3                
            };

            company.Workers = new List<Worker>
            {
                humrec, humrec1, humrec2, humrec3
            };

            Assert.Equal(workersList, company.Workers);
            Assert.Contains(humrec1, company.Workers); 
            Assert.DoesNotContain(humrec4, company.Workers); 
            Assert.Contains(workersList, worker => worker.LastName.Contains("Rivera"));
            humrec.Salary = "1800";
            humrec1.Salary = "1800";
            humrec2.Salary = "1800";
            humrec3.Salary = "1800";
            Assert.All(company.Workers, worker => Assert.False(string.IsNullOrWhiteSpace(worker.Salary)));
        }
    }
}
